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
using Graph_.Localization;

namespace Graph_
{
    public partial class MainWindow : Form
    {

        private Dictionary<int, HashSet<int>> parseList(StreamReader stream)
        {
            int cureVertex=-1;
            Dictionary<int, HashSet<int>> result = new Dictionary<int, HashSet<int>>();
            Dictionary<string, int> options = new Dictionary<string, int>();

            string[] currentString = new string[0];
            do
            {
                cureVertex = -1;
                if (currentString.Length == 3) { options.Add(currentString[0], int.Parse(currentString[2])); }
                currentString = stream.ReadLine().Split(' ');
            } while (stream.Peek()!=-1 && !int.TryParse(currentString[0], out cureVertex));



            while (cureVertex!=-1)
            {
                result.Add(cureVertex, new HashSet<int>());
                currentString = (string[])slice(currentString, 2);

                int[] adjacentVertices = currentString.Select(el => int.Parse(el)).ToArray();
                foreach (int adjacentVertex in adjacentVertices)
                {
                    result[cureVertex].Add(adjacentVertex);
                }

                if (stream.Peek() == -1)
                    break;
                
                currentString = stream.ReadLine().Split(' ');
                cureVertex = int.Parse(currentString[0]);
    
            }

            return result;
        }
        private int[][] parseMatrix(StreamReader stream, int? _verticesNumber = null)
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

            int[][] matrix = new int[verticesNumber][];
            matrix[0] = currentString.Select(el => int.Parse(el)).ToArray();

            for (int i = 1; i < verticesNumber; i++)
            {
                matrix[i] = stream.ReadLine().Split(' ').Select(el => int.Parse(el)).ToArray(); 
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
                        int[][] adjacencyMatrix = parseMatrix(fileStream);
                        graph.rewriteGraph(adjacencyMatrix);
                    }
                    catch { onError(titles.parseError); return false; }
                }
                else if (type[0] == "adjacency_list")
                {
                    try { graph.rewriteGraph(parseList(fileStream)); }
                    catch { onError(titles.parseError); return false; }
                }
                else { onError(titles.unknownFileError); return false; };
            }
            else if (type.Length == 3)
            {
                if (type[0] == "adjacency_matrix")
                {
                    try
                    {
                        int[][] adjacencyMatrix = parseMatrix(fileStream, int.Parse(type[2]));
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
