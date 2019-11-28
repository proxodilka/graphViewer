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

        public Dictionary<int, HashSet<int>> get()
        {
            Dictionary<int, HashSet<int>> copy = new Dictionary<int, HashSet<int>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new HashSet<int>(pair.Value.Keys));
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

        public Dictionary<int, Dictionary<int, int>> getWeighted()
        {
            Dictionary<int, Dictionary<int, int>> copy = new Dictionary<int, Dictionary<int, int>>();
            foreach (var pair in graph)
            {
                copy.Add(pair.Key, new Dictionary<int, int>(pair.Value));
            }
            return copy;
        }

        public int[,] getAsMatrix()
        {
            int[,] matrix = new int[verticesNumber, verticesNumber];
            foreach (var pair in graph)
            {
                foreach (var vertex in pair.Value)
                {
                    matrix[pair.Key, vertex.Key] = vertex.Value;
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
