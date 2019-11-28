using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public delegate void eventListener(object sender, GraphEventArgs e);

    public class GraphEventArgs
    {
        public int[] Vertices { get; }
        public int[] Edges { get; }

        public GraphEventArgs(int[] vertices, int [] edges)
        {
            Vertices = vertices; Edges = edges;
        }
    }

    public partial class Graph
    {
        public event eventListener vertexAdded;
        public event eventListener vertexRemoved;
        public event eventListener vertexModified;
        public event eventListener edgeModified;
        public event eventListener rewrite;
        public event eventListener isDirectedChanged;

        Dictionary<int, Dictionary<int, int>> graph; //Key - vertex number, Value - Dictionary of adjacency vertices and weight of edge
        public int verticesNumber, edgesNumber, maxVertexNumber=0;
        SortedSet<int> availableVerticesNumbers;
        const int MaxVerticesNumber = 100000;
        bool isDirected = false;

        public bool IsDirected { get { return isDirected; } set { isDirected = value; isDirectedChanged?.Invoke(this,new GraphEventArgs(new int[0], new int[0])); } }

        public Graph(bool isDirected = false)
        {
            init(isDirected);   
        }
        public Graph(int[][] adjacencyMatrix, bool isDirected=false):this(isDirected)
        {
            rewriteGraph(adjacencyMatrix);
        }

        public Graph(Dictionary<int, HashSet<int>> adjacencyList, bool isDirected = false) :this(isDirected)
        {
            rewriteGraph(adjacencyList);
        }

        private void init(bool? isDirected=null)
        {
            this.isDirected = isDirected??this.isDirected;
            availableVerticesNumbers = new SortedSet<int>();
            for (int i = 0; i < MaxVerticesNumber; i++) { availableVerticesNumbers.Add(i); }
            graph = new Dictionary<int, Dictionary<int, int>>();
            edgesNumber = 0; verticesNumber = 0;
        }

        public int addVertex(int? _vertexNumber=null, bool withoutEvent=false)
        {
            int vertexNumber = _vertexNumber ?? getNumber();
            if (graph.ContainsKey(vertexNumber)) {
                return vertexNumber;
            }

            graph.Add(vertexNumber, new Dictionary<int, int>());
            verticesNumber++;
            availableVerticesNumbers.Remove(vertexNumber);

            if (!withoutEvent)
            {
                vertexAdded?.Invoke(this, new GraphEventArgs(new int[1] { vertexNumber }, new int[0]));
                vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
            }
            return vertexNumber;
        }

        public bool addEdge(int from, int to, bool withoutEvent=false)
        {
            if (!hasVertex(from) || !hasVertex(to) || hasEdge(from, to) || from==to)
            {
                return false;
            }

            graph[from].Add(to, 1);
            //if (!isDirected) graph[to].Add(from, 1);
            edgesNumber++;

            if (!withoutEvent) edgeModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
            return true;
        }

        public bool addEdge(int from, int to, int weight, bool withoutEvent = false)
        {
            bool addingResult = addEdge(from, to, true);
            if (!addingResult)
            {
                return addingResult;
            }

            graph[from][to] = weight;
            //if (!isDirected) graph[to][from] = weight;
            if (!withoutEvent) edgeModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
            return addingResult;
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
            vertexRemoved?.Invoke(this, new GraphEventArgs(new int[1] { vertexNumber }, new int[0]));
            vertexModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
            return true;
        }

        public bool removeEdge(int from, int to, bool withoutEvent = false)
        {
            if (!hasVertex(from) || !hasVertex(to) || !hasEdge(from, to))
            {
                return false;
            }

            graph[from].Remove(to);
            if (!isDirected) graph[to].Remove(from);
            edgesNumber--;

            if (!withoutEvent) edgeModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
            return true;
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

            edgeModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
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

            edgeModified?.Invoke(this, new GraphEventArgs(new int[0], new int[0]));
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
            return graph.ContainsKey(from) && graph[from].ContainsKey(to);
        }


    }
}
