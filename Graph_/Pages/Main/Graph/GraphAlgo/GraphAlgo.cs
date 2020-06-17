using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graph_
{
    class GraphAlgo
    {
        Graph graph;
        Dictionary<int, HashSet<int>> graphList;
        int[] visited;
        List<int> ans;
             
        public GraphAlgo(Graph _graph)
        {
            graph = _graph;
            ans = new List<int>();
        }

        private void _dfs(int x, int colorValue, bool isFirst = true)
        {
            if (visited[x]!=0)
                return;
            visited[x] = colorValue;
            if (isFirst) ans.Add(x);

            foreach(int y in graphList[x])
            {
                if (x!=y && visited[y]==0)
                {
                    ans.Add(y);
                    _dfs(y, colorValue, false);
                    ans.Add(x);
                }
                
            }
        }

        public List<Tuple <int, int>> dfs(int start, int colorValue = 1, bool doNotClear = false)
        {
            if (!doNotClear) algoInit();
            _dfs(start, colorValue);
            return convertToRightAns(ans);
        }

        public List<Tuple<int, int>> bfs(int start, int colorValue = 1, bool doNotClear=false)
        {
            if (!doNotClear) algoInit();
            Queue<int> verticesQueue = new Queue<int>();
            verticesQueue.Enqueue(start);
            

            while (verticesQueue.Count != 0)
            {
                int vertex = verticesQueue.Dequeue();
                visited[vertex] = colorValue;
                ans.Add(vertex);
                foreach(int nextVertex in graphList[vertex])
                {
                    if (nextVertex!=vertex && visited[nextVertex]==0)
                    {
                        verticesQueue.Enqueue(nextVertex);
                        visited[nextVertex] = colorValue;
                    }
                }
            }

            return convertToRightAns(ans);
        }

        private int hasUnvisitedVertices()
        {
            foreach (var pair in graphList)
            {
                int vertex = pair.Key;
                if (visited[vertex] == 0) return vertex;
            }
            return -1;
        }

        public List<Tuple<int, int>> connectedComponents(int start)
        {
            algoInit();
            int unvisitedVertex = start, counter = 1;
            do
            {
                bfs(unvisitedVertex, counter, true);
                unvisitedVertex = hasUnvisitedVertices();
                counter++;
            } while (unvisitedVertex != -1);

            return convertToRightAns(ans);
        }

        public async Task<bool> TSP_BFS(int start, Updater updater, CancellationToken cancelation)
        {
            await new TSP(graph.getAsMatrix(), start).bruteForceSearch(updater, cancelation);
            return true;
        }

        public async Task<bool> TSP_BNB(int start, Updater updater, CancellationToken cancelation)
        {
            await new TSP(graph.getAsMatrix(), start).branchAndBound(updater, cancelation);
            return true;
        }

        public async Task<bool> TSP_Evol(int start, Updater updater, CancellationToken cancelation, Dictionary<string, int> args)
        {
            await new TSP(graph.getAsMatrix(), start, args).simpleEvolutionAlgo(updater, cancelation);
            return true;
        }

        public Tuple<double, List<int>> TSP_Greedy(int start)
        {
            return new TSP(graph.getAsMatrix(), start).greedy();
        }

        private void algoInit()
        {
            ans.Clear();
            visited = new int[graph.getMaxVertexNumber()+1];
            graphList = graph.getForAlgo();
        }

        private List<Tuple<int,int>> convertToRightAns(List<int> list)
        {
            List<Tuple<int, int>> ans = new List<Tuple<int, int>>();
            foreach(int value in list)
            {
                ans.Add(new Tuple<int, int>(value, visited[value]));
            }
            return ans;
        }
    }
}
