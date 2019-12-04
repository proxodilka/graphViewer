using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class Graph
    {
        public string getAsList()
        {
            string ans = "";

            foreach (var _value in graph)
            {
                ans += $"{_value.Key} : ";
                foreach (var vertices in _value.Value)
                {
                    ans += $"{vertices.Key}-{vertices.Value} ";
                }
                ans += "\n";
            }

            return ans;
        }

        public List<string> getVerticesNumbers()
        {
            return graph.Keys.Select((x)=>x.ToString()).ToList();
        }

        public List<int> getVerticesNumbersAsInt()
        {
            return graph.Keys.ToList();
        }

        public Dictionary<int, HashSet<int>> getAdjList()
        {
            Dictionary<int, HashSet<int>> copy = new Dictionary<int, HashSet<int>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new HashSet<int>(pair.Value.Keys));
            }
            return copy;
        }

        public Dictionary<int, Dictionary<int, double>> get()
        {

            Dictionary<int, Dictionary<int, double>> copy = new Dictionary<int, Dictionary<int, double>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new Dictionary<int, double>(pair.Value));
            }
            return copy;
        }

        public Dictionary<int, HashSet<int>> getForAlgo()
        {
            Dictionary<int, HashSet<int>> copy = new Dictionary<int, HashSet<int>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new HashSet<int>(pair.Value.Keys));
            }
            if (!isDirected)
            {
                foreach(var pair in copy)
                {
                    foreach(int vertex in pair.Value)
                    {
                        copy[vertex].Add(pair.Key);
                    }
                }
            }
            return copy;
        }

        public Dictionary<int, Dictionary<int, double>> getWeighted()
        {
            Dictionary<int, Dictionary<int, double>> copy = new Dictionary<int, Dictionary<int, double>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new Dictionary<int, double>(pair.Value));
            }
            return copy;
        }

        public double[,] getAsMatrix()
        {
            var vertices = graph.Keys.ToList();
            double[,] matrix = new double[verticesNumber, verticesNumber];
            {
                int i = 0;
                foreach (var pair in graph)
                {
                    foreach (var vertex in pair.Value)
                    {
                        int j = vertices.FindIndex((x)=>x==vertex.Key);
                        //matrix[pair.Key, vertex.Key] = vertex.Value;
                        matrix[i, j] = vertex.Value;
                    }
                    i++;
                }
            }
            if (!isDirected)
            {
                for(int i=0; i<matrix.GetLength(0); i++)
                {
                    for(int j=0; j<matrix.GetLength(1); j++)
                    {
                        if (i > j)
                            continue;
                        if (matrix[i,j]!=0 && matrix[j, i] == 0)
                        {
                            matrix[j, i] = matrix[i, j];
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
