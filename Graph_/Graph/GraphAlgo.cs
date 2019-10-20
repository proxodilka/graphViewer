using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    class GraphAlgo
    {
        Graph graph;
        Dictionary<int, HashSet<int>> graphList;
        bool[] visited;
        List<int> ans;

        public GraphAlgo(Graph _graph)
        {
            graph = _graph;
            ans = new List<int>();
        }

        private void _dfs(int x, bool isFirst = true)
        {
            if (visited[x])
                return;
            visited[x] = true;
            if (isFirst) ans.Add(x);

            foreach(int y in graphList[x])
            {
                if (x!=y && !visited[y])
                {
                    ans.Add(y);
                    _dfs(y, false);
                    ans.Add(x);
                }
                
            }
        }

        public List<int> dfs(int start)
        {
            algoInit();
            _dfs(start);
            return ans;
        }

        public List<int> bfs(int start)
        {
            algoInit();
            Queue<int> verticesQueue = new Queue<int>();
            verticesQueue.Enqueue(start);
            

            while (verticesQueue.Count != 0)
            {
                int vertex = verticesQueue.Dequeue();
                visited[vertex] = true;
                ans.Add(vertex);
                foreach(int nextVertex in graphList[vertex])
                {
                    if (nextVertex!=vertex && !visited[nextVertex])
                    {
                        verticesQueue.Enqueue(nextVertex);
                        visited[nextVertex] = true;
                    }
                }
            }

            return ans;
        }

        private void algoInit()
        {
            ans.Clear();
            visited = new bool[graph.getMaxVertexNumber()+1];
            graphList = graph.get();
        }
    }
}
