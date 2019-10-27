using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    delegate void eventListener(object sender, GraphEventArgs e);

    class GraphEventArgs
    {
        int from { get; }
        int to { get; }

        public GraphEventArgs(int from =-1, int to =-1)
        {
            this.from = from; this.to = to;
        }
    }

    class Graph
    {
        public event eventListener vertexModified;
        public event eventListener edgeModified;
        Dictionary<int, HashSet<int>> graph; //Key - vertex number, Value - Set of adjacency vertices
        public int verticesNumber, edgesNumber, maxVertexNumber=0;
        SortedSet<int> availableVerticesNumbers;
        const int MaxVerticesNumber = 100000;

        public Graph()
        {
            init();   
        }
        public Graph(int[][] adjacencyMatrix):this()
        {
            rewriteGraph(adjacencyMatrix);
        }

        public Graph(Dictionary<int, HashSet<int>> adjacencyList):this()
        {
            rewriteGraph(adjacencyList);
        }

        private void init()
        {
            availableVerticesNumbers = new SortedSet<int>();
            for (int i = 0; i < MaxVerticesNumber; i++) { availableVerticesNumbers.Add(i); }
            graph = new Dictionary<int, HashSet<int>>();
            edgesNumber = 0; verticesNumber = 0;
        }

        public void rewriteGraph(int[][] adjacencyMatrix)
        {
            init();
            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                addVertex(i, true);
                for (int j = 0; j < adjacencyMatrix.Length; j++)
                {
                    if (adjacencyMatrix[i][j] == 1)
                    {
                        addEdge(i, j, true);
                    }
                }
            }

            vertexModified?.Invoke(this, new GraphEventArgs());
        }

        public void rewriteGraph(Dictionary<int, HashSet<int>> adjacencyList)
        {
            init();
            foreach (var listValue in adjacencyList)
            {
                int vertex = listValue.Key;
                addVertex(vertex, true);
                foreach (int adjacentVertex in listValue.Value)
                {
                    addEdge(vertex, adjacentVertex, true);
                }
            }

            vertexModified?.Invoke(this, new GraphEventArgs());
        }

        public void rewriteGraph()
        {
            init();
            vertexModified?.Invoke(this, new GraphEventArgs());
        }

        public int addVertex(int? _vertexNumber=null, bool withoutEvent=false)
        {
            int vertexNumber = _vertexNumber ?? getNumber();
            if (graph.ContainsKey(vertexNumber)) {
                return vertexNumber;
            }

            graph.Add(vertexNumber, new HashSet<int>());
            verticesNumber++;
            availableVerticesNumbers.Remove(vertexNumber);

            if (!withoutEvent) vertexModified?.Invoke(this, new GraphEventArgs());
            return vertexNumber;
        }

        public bool addEdge(int from, int to, bool withoutEvent=false)
        {
            if (!hasVertex(from) || !hasVertex(to) || hasEdge(from, to))
            {
                return false;
            }

            graph[from].Add(to);
            graph[to].Add(from);
            edgesNumber++;

            if (!withoutEvent) edgeModified?.Invoke(this, new GraphEventArgs(Math.Min(from, to), Math.Max(from, to)));
            return true;
        }

        public bool removeVertex(int vertexNumber)
        {
            if (!hasVertex(vertexNumber)){
                return false;
            }

            edgesNumber-=graph[vertexNumber].Count();
            verticesNumber--;
            graph.Remove(vertexNumber);
            
            foreach(var vertex in graph){
                vertex.Value.Remove(vertexNumber);
            }

            availableVerticesNumbers.Add(vertexNumber);
            vertexModified?.Invoke(this, new GraphEventArgs());
            return true;
        }

        public bool removeEdge(int from, int to, bool withoutEvent = false)
        {
            if (!hasVertex(from) || !hasVertex(to) || !hasEdge(from, to))
            {
                return false;
            }

            graph[from].Remove(to);
            graph[to].Remove(from);
            edgesNumber--;

            if (!withoutEvent) edgeModified?.Invoke(this, new GraphEventArgs(Math.Min(from, to), Math.Max(from, to)));
            return true;
        }

        //public int[,] getAsMatrix()
        //{
        //    int[,] ans = new int[verticesNumber, verticesNumber];

        //}

        public string getAsList()
        {
            string ans = "";

            foreach(var _value in graph)
            {
                ans += $"{_value.Key} : ";
                foreach(var vertices in _value.Value)
                {
                    ans += $"{vertices} ";
                }
                ans += "\n";
            }

            return ans;
        }

        public void makeGraphComplete()
        {
            List<int> vertices = new List<int>(graph.Keys);

            foreach(int srcVertex in vertices)
            {
                foreach(int vertex in vertices)
                {
                    if (srcVertex!=vertex)
                        addEdge(srcVertex, vertex, true);
                }
            }

            edgeModified?.Invoke(this, new GraphEventArgs());
        }

        public void clearEdges()
        {
            List<int> vertices = new List<int>(graph.Keys);

            foreach (int srcVertex in vertices)
            {
                foreach (int vertex in vertices)
                {
                    removeEdge(srcVertex, vertex, true);
                }
            }

            edgeModified?.Invoke(this, new GraphEventArgs());
        }

        public Dictionary<int, HashSet<int>> get()
        {
            Dictionary<int, HashSet<int>> copy = new Dictionary<int, HashSet<int>>();
            foreach(var pair in graph)
            {
                copy.Add(pair.Key, new HashSet<int>(pair.Value));
            }
            return copy;
        }

        public int getNumber()
        {
            return availableVerticesNumbers.Min;
        }

        public int getMaxVertexNumber()
        {
            return verticesNumber > 0 ? graph.Keys.Max() : 0;
        }

        public int getMinVertexNumber()
        {
            return verticesNumber > 0 ? graph.Keys.Min() : 0;
        }

        public bool hasVertex(int n)
        {
            return graph.ContainsKey(n);
        }

        public bool hasEdge(int from, int to)
        {
            return graph.ContainsKey(from) && graph[from].Contains(to);
        }

    }
}
