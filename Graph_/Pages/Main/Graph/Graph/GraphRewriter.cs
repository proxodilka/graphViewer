using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class Graph
    {

        public void updateGraph<T>(T[,] adjacencyMatrix)
        {
            int i = 0;
            var vertices = graph.Keys.ToList();
            Dictionary<int, Dictionary<int, double>> updatedGraph = new Dictionary<int, Dictionary<int, double>>();
            foreach(var pair in graph)
            {
                updatedGraph.Add(pair.Key, new Dictionary<int, double>());
                for(int j=0; j<adjacencyMatrix.GetLength(0); j++)
                {
                    double weight = Convert.ToDouble(adjacencyMatrix[i, j]);
                    if (weight != 0)
                    {
                        updatedGraph[pair.Key][vertices[j]] = weight;
                    }
                }
                i++;
            }
            rewriteGraph(updatedGraph);
        }
        public void rewriteGraph<T>(T[][] adjacencyMatrix)
        {
            init();

            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                addVertex(i, true);
            }

            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                for (int j = 0; j < adjacencyMatrix.Length; j++)
                {
                    if (!adjacencyMatrix[i][j].Equals(0))
                    {
                        addEdge(i, j, adjacencyMatrix[i][j], true);
                    }
                }
            }

            rewrite?.Invoke(this, new GraphEventArgs(graph.Keys.ToArray(), new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
        }

        public void rewriteGraph(double[,] adjacencyMatrix)
        {
            init();

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                addVertex(i, true);
            }

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != 0)
                    {
                        addEdge(i, j, adjacencyMatrix[i, j], true);
                    }
                }
            }

            rewrite?.Invoke(this, new GraphEventArgs(graph.Keys.ToArray(), new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
        }

        public void rewriteGraph(Dictionary<int, HashSet<int>> adjacencyList)
        {
            init();

            foreach (var listValue in adjacencyList)
            {
                int vertex = listValue.Key;
                addVertex(vertex, true);
            }

            foreach (var listValue in adjacencyList)
            {
                int vertex = listValue.Key;
                foreach (int adjacentVertex in listValue.Value)
                {
                    addEdge(vertex, adjacentVertex, true);
                }
            }

            rewrite?.Invoke(this, new GraphEventArgs(graph.Keys.ToArray(), new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
        }

        public void rewriteGraph(Dictionary<int, Dictionary<int, double>> adjacencyList)
        {
            init();

            foreach (var listValue in adjacencyList)
            {
                int vertex = listValue.Key;
                addVertex(vertex, true);
            }

            foreach (var listValue in adjacencyList)
            {
                int vertex = listValue.Key;
                foreach (var adjacentVertex in listValue.Value)
                {
                    addEdge(vertex, adjacentVertex.Key, adjacentVertex.Value, true);
                }
            }

            rewrite?.Invoke(this, new GraphEventArgs(graph.Keys.ToArray(), new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
        }

        public void rewriteGraph()
        {
            init();
            rewrite?.Invoke(this, new GraphEventArgs(graph.Keys.ToArray(), new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
        }
    }
}
