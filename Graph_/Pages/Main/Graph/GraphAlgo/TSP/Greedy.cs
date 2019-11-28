using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class TSP
    {
        bool[] greedyMarkedVertices;

        bool _greedy(List<int> way, long weight, int position, int stepNumber, ref Tuple<int, List<int>> ans)
        {
            if (stepNumber == numberOfVertices - 1) //if all vertices are visited
            {
                weight += matrix[position, start];
                way.Add(start);
                if (weight >= INF) //if somewhere we've made a traversal through nonexistent edge
                {                  //then let's try another edge in previous step
                    way.RemoveAt(way.Count - 1);
                    weight -= matrix[position, start];
                    return false;
                }
                else
                {
                    ans = new Tuple<int, List<int>>((int)weight, new List<int>(way));
                    return true;
                }

            }

            List<Tuple<int, long>> adjacencyVertices = new List<Tuple<int, long>>();
            for (int i = 0; i < numberOfVertices; i++)  //loop for all of adjacency vertices
            {
                if (i == position || greedyMarkedVertices[i])
                {
                    continue;
                }
                adjacencyVertices.Add(new Tuple<int, long>(i, matrix[position, i]));
            }

            adjacencyVertices.Sort((a, b) => (a.Item2 == b.Item2) ? 0 : ((a.Item2 < b.Item2) ? -1 : 1)); //sorting them by weight
            foreach (var pair in adjacencyVertices)
            {
                way.Add(pair.Item1);
                weight += pair.Item2;
                greedyMarkedVertices[pair.Item1] = true;
                bool greedyResult = _greedy(way, weight, pair.Item1, stepNumber + 1, ref ans); 
                if (greedyResult) //if in this case we've made a traversal without using 'fake' edges
                {
                    return true;
                }
                weight -= pair.Item2; //otherwise we're trying another edge
                way.RemoveAt(way.Count - 1);
                greedyMarkedVertices[pair.Item1] = false;
            }
            return false; //from this position we cannot make full traversal, so getting back on previous step and trying another edge
        }

        Tuple<int, List<int>> greedyWrapper(List<int> way, long weight, int position, int stepNumber)
        {
            greedyMarkedVertices = new bool[numberOfVertices];
            foreach (int vertex in way)
            {
                greedyMarkedVertices[vertex] = true;
            }
            Tuple<int, List<int>> ans = null;
            _greedy(new List<int>(way), weight, position, stepNumber, ref ans);
            return ans;
        }

        public Tuple<int, List<int>> greedy()
        {
            return greedyWrapper(new List<int>() { start }, 0, start, 0);
        }
    }
}
