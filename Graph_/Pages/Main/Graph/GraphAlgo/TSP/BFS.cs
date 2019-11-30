using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class TSP
    {
        async void BFS(List<int> way, long weight, int position, int stepNumber)
        {
            if (stepNumber == numberOfVertices - 1) //if all vertices are visited
            {
                weight += matrix[position, start];
                way.Add(start);
                if (weight < currentOptimalWeight)
                {
                    ans = new List<int>(way);
                    currentOptimalWeight = weight;
                    updater(new Tuple<int, List<int>>((int)currentOptimalWeight, ans));
                }
                way.RemoveAt(way.Count - 1);
                weight -= matrix[position, start];
                return;
            }

            for (int i = 0; i < numberOfVertices; i++)
            {
                if (i == position || markedVertices[i])
                {
                    continue;
                }
                way.Add(i);
                weight += matrix[position, i];
                markedVertices[i] = true;
                BFS(way, weight, i, stepNumber + 1);
                weight -= matrix[position, i];
                way.RemoveAt(way.Count - 1);
                markedVertices[i] = false;
            }
        }

        public async void bruteForceSearch(Updater updater)
        {
            this.updater = updater;
            setTSP(matrix, start);
            markedVertices[start] = true;
            Task.Run(()=>BFS(new List<int>() { start }, 0, start, 0));
            //BFS(new List<int>() { start }, 0, start, 0);

            //return (currentOptimalWeight >= INF) ? null : new Tuple<int, List<int>>((int)currentOptimalWeight, ans);
        }
    }
}
