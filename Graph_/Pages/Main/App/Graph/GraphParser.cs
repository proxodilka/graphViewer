﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Graph_.Pages.Main.App.Localization;
using System.Globalization;

namespace Graph_
{
    public partial class MainWindow : Form
    {


        private Tuple<Dictionary<int, Dictionary<int, double>>, Dictionary<int, PointF>, Dictionary<string, int>> parseCoords(StreamReader stream)
        {
            int nOfVertex = -1;
            Dictionary<int, Dictionary<int, double>> result = new Dictionary<int, Dictionary<int, double>>();
            Dictionary<string, int> options = new Dictionary<string, int>();
            Dictionary<int, PointF> coordinates = new Dictionary<int, PointF>();
            bool hasCoordinates = false;

            string[] currentString = new string[0];
            do
            {
                nOfVertex = -1;
                if (currentString.Length == 3) { options.Add(currentString[0], int.Parse(currentString[2])); }
                currentString = stream.ReadLine().Split(' ');
            } while (stream.Peek() != -1 && !int.TryParse(currentString[0], out nOfVertex));

            int vertexNumber = 0;
            while (vertexNumber<nOfVertex && stream.Peek() != -1)
            {
                currentString = stream.ReadLine().Split(' ');

                PointF coords = new PointF(float.Parse(currentString[0].Replace(',', '.'), CultureInfo.CreateSpecificCulture("en-us")),
                                           float.Parse(currentString[1].Replace(',', '.'), CultureInfo.CreateSpecificCulture("en-us")));
                coordinates.Add(vertexNumber, coords);
                result.Add(vertexNumber, new Dictionary<int, double>());
                vertexNumber++;
            }

            return new Tuple<Dictionary<int, Dictionary<int, double>>, Dictionary<int, PointF>, Dictionary<string, int>>(result, coordinates, options);
        }


        /// <summary>
        /// Returns tuple of adjacency list and nodes coordinates
        /// </summary>
        private Tuple<Dictionary<int, Dictionary<int, double>>, Dictionary<int,PointF>, Dictionary<string, int>> parseList(StreamReader stream)
        {
            int cureVertex=-1;
            Dictionary<int, Dictionary<int, double>> result = new Dictionary<int, Dictionary<int, double>>();
            Dictionary<string, int> options = new Dictionary<string, int>();
            Dictionary<int, PointF> coordinates = new Dictionary<int, PointF>();
            bool hasCoordinates = false;

            string[] currentString = new string[0];
            do
            {
                cureVertex = -1;
                if (currentString.Length == 3) { options.Add(currentString[0], int.Parse(currentString[2])); }
                currentString = stream.ReadLine().Split(' ');
            } while (stream.Peek()!=-1 && !int.TryParse(currentString[0], out cureVertex));



            while (cureVertex!=-1)
            {
                result.Add(cureVertex, new Dictionary<int, double>());
                currentString = (string[])slice(currentString, 2);

                //int[] adjacentVertices = currentString.Select(el => int.Parse(el)).ToArray();
                foreach(string vertexInfo in currentString)
                {
                    string[] vertexWeight = vertexInfo.Split('-');
                    int vertex = int.Parse(vertexWeight[0]);
                    double weight = vertexWeight.Length == 1 ? 1 : double.Parse(vertexWeight[1].Replace(',', '.'), CultureInfo.CreateSpecificCulture("en-us"));
                    result[cureVertex].Add(vertex, weight);
                }

                if (stream.Peek() == -1)
                    break;
                
                currentString = stream.ReadLine().Split(' ');
                if (currentString[0] == "coordinates")
                {
                    hasCoordinates = true;
                    break;
                }
                cureVertex = int.Parse(currentString[0]); 
            }

            while (hasCoordinates && stream.Peek() != -1)
            {
                currentString = stream.ReadLine().Split(' ');

                int vertexNumber = int.Parse(currentString[0]);
                PointF coords = new PointF(float.Parse(currentString[2].Replace(',','.'), CultureInfo.CreateSpecificCulture("en-us")),
                                           float.Parse(currentString[3].Replace(',','.'), CultureInfo.CreateSpecificCulture("en-us")));
                coordinates.Add(vertexNumber, coords);
            }

            return new Tuple<Dictionary<int, Dictionary<int, double>>, Dictionary<int, PointF>, Dictionary<string, int>>(result, coordinates, options);
        }
        private double[][] parseMatrix(StreamReader stream, int? _verticesNumber = null)
        {
            int verticesNumber= _verticesNumber??0;
            int cureVertex = 0;
            string[] currentString = new string[0];
            Dictionary<string, int> options = new Dictionary<string, int>();

            do
            {
                if (currentString.Length == 3) { options.Add(currentString[0], int.Parse(currentString[2])); }
                currentString = stream.ReadLine().Split(' ');
            } while (stream.Peek() != -1 && !int.TryParse(currentString[0], out cureVertex));

            if (options.ContainsKey("vertices_number"))
                verticesNumber = options["vertices_number"];

            double[][] matrix = new double[verticesNumber][];
            matrix[0] = currentString.Select(el => double.Parse(el.Replace(',', '.'), CultureInfo.CreateSpecificCulture("en-us"))).ToArray();

            for (int i = 1; i < verticesNumber; i++)
            {
                matrix[i] = stream.ReadLine().Split(' ').Select(el => double.Parse(el.Replace(',', '.'), CultureInfo.CreateSpecificCulture("en-us"))).ToArray(); 
            }

            return matrix;
        }

        private string detectType(string line)
        {
            string[] words = line.Split(' ');
            if (words.Length == 3)
            {
                if (words[0] == "type" && words[1] == ":")
                {
                    return words[2];
                }
                else
                {
                    return "undetected_type";
                }
            }
            else if (words.Length == 1)
            {
                int res;
                if (!int.TryParse(words[0], out res))
                {
                    return "undetected_type";
                }
                else
                {
                    return $"adjacency_matrix : {res}";
                }
            }
            else
            {
                return "undetected_type";
            }

        }

        private bool tryToParseGraph(StreamReader fileStream, string[] type)
        {
            if (type.Length == 1)
            {
                if (type[0] == "undetected_type") { onError(titles.unknownFileError); return false; }
                else if (type[0] == "adjacency_matrix")
                {
                    try
                    {
                        double[][] adjacencyMatrix = parseMatrix(fileStream);
                        graph.rewriteGraph(adjacencyMatrix);
                    }
                    catch { onError(titles.parseError); return false; }
                }
                else if (type[0] == "adjacency_list")
                {
                    try {
                        var parseResult = parseList(fileStream);
                        graph.rewriteGraph(parseResult.Item1);
                        graphVisual.setNodesCoords(parseResult.Item2);
                        graph.IsDirected = parseResult.Item3.ContainsKey("is_directed")? (parseResult.Item3["is_directed"] == 1) : false;
                        graphVisual.IsWeighted = parseResult.Item3.ContainsKey("is_weighted") ? (parseResult.Item3["is_weighted"] == 1) : false;
                    }
                    catch { onError(titles.parseError); return false; }    
                }
                else if (type[0] == "coordinates")
                {
                    //try
                    //{
                        var parseResult = parseCoords(fileStream);
                        graph.rewriteGraph(parseResult.Item1);
                        graphVisual.setNodesCoords(parseResult.Item2);

                        graph.IsDirected = parseResult.Item3.ContainsKey("is_directed") ? (parseResult.Item3["is_directed"] == 1) : false;
                        graphVisual.IsWeighted = parseResult.Item3.ContainsKey("is_weighted") ? (parseResult.Item3["is_weighted"] == 1) : false;

                        graph.makeGraphComplete();
                        setWeightsByCoords();
                    //}
                    //catch { onError(titles.parseError); return false; }
                }
                else { onError(titles.unknownFileError); return false; };
            }
            else if (type.Length == 3)
            {
                if (type[0] == "adjacency_matrix")
                {
                    try
                    {
                        double[][] adjacencyMatrix = parseMatrix(fileStream, int.Parse(type[2]));
                        graph.rewriteGraph(adjacencyMatrix);
                    }
                    catch { onError(titles.parseError); return false; }
                }
                else { onError(titles.unknownFileError); return false; };
            }

            return true;
        }

        private Array slice(Array arr, int start, int? _end = null)
        {
            int end = _end ?? arr.Length - start;
            string[] res = new string[end - start + 1];
            Array.Copy(arr, start, res, 0, end - start + 1);
            return res;
        }

    }
}
