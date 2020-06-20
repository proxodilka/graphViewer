import subprocess as sub
import argparse
import tempfile
import cloudinary
from cloudinary.uploader import upload
import re
import json

import os
import warnings
import mysql.connector

import multiprocessing

is_path = ["data_path", "executor", "params", "config"]
ERROR_IMG = "https://res.cloudinary.com/dsp5c2jts/image/upload/v1592664249/error_pn2wvi.jpg"
paths_to_clear = []
args = {}


def read_config(args):
    config = json.loads(get_file_content(args["config"], no_formating=True))

    if config.get("mysql", None) is None:
        warnings.warn("MYSQL Database configuration is missed at config file.")
    if config.get("cloudinary", None) is None:
        warnings.warn("Cloudinary configuration is missed at config file.")

    args.update(config.get("mysql", {}))
    args.update(config.get("cloudinary", {}))


def config_cloudinary(args):
    cloudinary.config(
        cloud_name=args["cloud_name"], api_key=args["api_key"], api_secret=args["api_secret"]
    )


def interface():
    parser = argparse.ArgumentParser()
    parser.add_argument("--data_path", "-d", required=True, help="Path to a file with graph.")
    parser.add_argument(
        "--time",
        "-t",
        required=False,
        default="60",
        help="Time in seconds that TSP solver will work.",
    )
    parser.add_argument(
        "--method", "-m", required=False, default="evolv", help="Method to solve TSP."
    )
    parser.add_argument(
        "--params",
        "-p",
        required=False,
        default="settings.json",
        help="Params for selected TSP method.",
    )
    parser.add_argument(
        "--executor",
        "-e",
        required=False,
        default="Graph_/bin/Debug/Graph_.exe",
        help="Path to TSP executor.",
    )
    parser.add_argument(
        "--config", "-c", required=False, default="config.json", help="Path to config file."
    )
    parser.add_argument("--num_runs", "-n", required=False, default=1, help="Number of runs.")

    return vars(parser.parse_args())


def validate_arguments(args):
    for path in is_path:
        args[path] = os.path.abspath(args[path])

    for path in is_path:
        if not os.path.exists(args[path]):
            raise RuntimeError(f"File does not exists {path}: {args[path]}")


def run_solver(args):
    output = {}

    file_descriptor, img_path = tempfile.mkstemp(suffix=".png")
    os.close(file_descriptor)

    paths_to_clear.append(img_path)

    proc = sub.Popen(
        [
            args["executor"],
            args["data_path"],
            args["method"],
            args["params"],
            img_path,
            args["time"],
        ],
        stdin=sub.PIPE,
        stdout=sub.PIPE,
        stderr=sub.PIPE,
        text=True,
    )
    outs, errs = proc.communicate()

    # works incorrect for now
    if False and errs is not None:
        raise RuntimeError(f"TSP solver raised an exception, traceback: \n{errs}")

    outs = outs.splitlines()
    outs = outs[len(outs) - 1].split(" ")

    output["way_length"] = outs[0]
    output["way"] = " ".join(outs[1:])
    output["way_img"] = img_path

    return output


def get_meta_data(filepath):
    pattern = r"([A-Z,_]+)\s*:\s*([\w,\d]+)"
    settings = {}
    with open(filepath) as file:
        for line in file:
            if line.split("_")[-1] == "SECTION":
                break
            reg = re.search(pattern, line)
            if reg is not None:
                settings[reg.group(1)] = reg.group(2)

    filename, _ = os.path.splitext(filepath)
    return {
        "dataset_name": settings.get("NAME", filename),
        "dataset_size": settings.get("DIMENSION", "-1"),
    }


def upload_image(args):
    try:
        upload_result = upload(args["way_img"])
    except cloudinary.exceptions.Error as e:
        print(
            "An error occured while reporting image of way. Picture will be replased by dummy one.\nTraceback:\n",
            e,
        )
        args["way_img"] = ERROR_IMG
    else:
        args["way_img"] = upload_result["secure_url"]


def report_results(args, results):
    table_name = "results"
    mydb = mysql.connector.connect(
        host=args["db_host"],
        user=args["db_user"],
        password=args["db_pass"],
        database=args["db_name"],
    )

    def stringify(x):
        return "'" + str(x) + "'"

    cursor = mydb.cursor()
    result_keys = results.keys()

    query = f"INSERT INTO {table_name} ({','.join(result_keys)}) VALUES({','.join(map(stringify, [results[key] for key in result_keys]))});"
    cursor.execute(query)
    mydb.commit()


def get_file_content(path, no_formating=False):
    with open(path, "r") as file:
        content = file.read()
        if not no_formating:
            return re.sub(r"\s+", " ", content.replace("\n", ""))
        else:
            return content

def work(args):
    config_cloudinary(args)
    results = run_solver(args)
    results.update(get_meta_data(args["data_path"]))
    results.update(
        {
            "run_time": args["time"],
            "method": args["method"],
            "tsp_params": get_file_content(args["params"]),
        }
    )
    upload_image(results)
    report_results(args, results)

if __name__ == "__main__":
    args.update(interface())
    validate_arguments(args)
    read_config(args)
    
    processes = []
    for _ in range(int(args["num_runs"])):
        p = multiprocessing.Process(target=work, args=[args])
        p.start()
        processes.append(p)
    
    for p in processes:
        p.join()
    
    print("Done.")
