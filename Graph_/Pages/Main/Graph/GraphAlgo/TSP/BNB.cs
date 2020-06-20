using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class TSP
    {
        class Branch
        {
            double lowerBound, currentWeight;
            double[,] distances;
            bool[] markedVertices;
            Tuple<double, List<int>> upperBound;
            int numberOfVertices;
            List<int> way;

            public int Position { get { return way[way.Count-1]; } }
            public int Start { get { return way[0]; } }


            public double LowerBound { get { return lowerBound; } }
            public double UpperBound { get { return upperBound.Item1; } }

            public Tuple<double, List<int>> Answer { get { return new Tuple<double, List<int>>(upperBound.Item1, new List<int>(upperBound.Item2)); } }

            public List<int> Way { get { return way; } }

            Branch(double[,] distances)
            {
                way = new List<int>();
                markedVertices = new bool[distances.GetLength(0)];
                this.distances = distances;
                numberOfVertices = distances.GetLength(0);
            }

            public Branch(int start, double[,] distances) : this(distances)
            {
                addToPath(start);
            }

            public Branch(List<int> way, double lowerBound, double currentWeight, double[,] distances)
            {
                this.way = new List<int>(way);
                this.lowerBound = lowerBound;
                this.upperBound = new Tuple<double, List<int>>(10e6, new List<int>());
                this.currentWeight = currentWeight;
                this.distances = distances;
                markedVertices = new bool[distances.GetLength(0)];
                numberOfVertices = distances.GetLength(0);
            }

            public Branch(Branch other)
            {
                lowerBound = other.lowerBound;
                upperBound = new Tuple<double, List<int>>(other.upperBound.Item1, new List<int>(other.upperBound.Item2));
                currentWeight = other.currentWeight;
                way = new List<int>(other.way);
                distances = other.distances;
                markedVertices = new bool[distances.GetLength(0)];
                numberOfVertices = other.numberOfVertices;
                for (int i=0; i<markedVertices.Length; i++)
                {
                    markedVertices[i] = other.markedVertices[i];
                }
            }

            public bool isVisited(int vertex)
            {
                return markedVertices[vertex];
            }

            void updateBounds()
            {
                getLowerBound();
                getUpperBound();
            }

            public void addToPath(int vertex)
            {
                if (way.Count!=0) currentWeight += distances[way.Last(), vertex];
                markedVertices[vertex] = true;
                way.Add(vertex);
                updateBounds();
            }

            void getLowerBound()
            {
                double weight = this.currentWeight;
                
                for(int i=0; i<numberOfVertices; i++)
                {
                    if (markedVertices[i] && i!=way.Last())
                    {
                        continue;
                    }

                    double minWeightInCol = 10e9;
                    for(int j=0; j<numberOfVertices; j++)
                    {
                        if (distances[i, j] < minWeightInCol)
                        {
                            minWeightInCol = distances[i, j];
                        }
                    }
                    weight += minWeightInCol;
                }

                lowerBound = weight;
                
            }

            void getUpperBound()
            {

                double newUpperBoundWeight = currentWeight;
                List<int> newUpperBoundWay = new List<int>(way);
                bool[] tempMarkedVertices = new bool[markedVertices.Length];
                for(int i=0; i<markedVertices.Length; i++)
                {
                    tempMarkedVertices[i] = markedVertices[i];
                }

                int cureVertex;
                for(int i=0; i<numberOfVertices-way.Count; i++)
                {
                    cureVertex = newUpperBoundWay.Last();

                    double minAdjacencyVertexWeight = 10e6;
                    int minAdjacencyVertexId = 0;

                    for(int j=0; j<numberOfVertices; j++)
                    {
                        if (tempMarkedVertices[j] || j == cureVertex)
                        {
                            continue;
                        }
                        if (distances[cureVertex, j] < minAdjacencyVertexWeight)
                        {
                            minAdjacencyVertexWeight = distances[cureVertex, j];
                            minAdjacencyVertexId = j;
                        }

                    }

                    tempMarkedVertices[minAdjacencyVertexId] = true;
                    newUpperBoundWeight += minAdjacencyVertexWeight;
                    newUpperBoundWay.Add(minAdjacencyVertexId);

                }

                cureVertex = newUpperBoundWay.Last();
                newUpperBoundWeight += distances[cureVertex, Start];
                newUpperBoundWay.Add(Start);

                upperBound = new Tuple<double, List<int>>(newUpperBoundWeight, newUpperBoundWay);
            }

        }

        
        void removeNotPerspectiveBranches(HashSet<Branch> branches)
        {
            Branch branchWithMinimumUpperBound = null;
            double minimumUpperBound = 10e6;

            foreach (Branch branch in branches)
            {
                if (branch.UpperBound < minimumUpperBound)
                {
                    branchWithMinimumUpperBound = branch;
                    minimumUpperBound = branch.UpperBound;
                }
            }

            branches.RemoveWhere((branchToDel) => { return branchToDel.Equals(branchWithMinimumUpperBound) ? false : branchToDel.LowerBound >= minimumUpperBound; });
        }

        double currentBestAnswer = 10e6;

        async void BNB(CancellationToken cancel)
        {
            HashSet<Branch> branches = new HashSet<Branch>() { new Branch(start, matrix) };
            List<Branch> branchesToAdd = new List<Branch>(),
                         branchesToDel = new List<Branch>();

            for (int i=0; i<numberOfVertices-1; i++)
            {

                removeNotPerspectiveBranches(branches);

                branchesToAdd.Clear();
                branchesToDel.Clear();
                foreach (Branch branch in branches)
                {
                    if (cancel.IsCancellationRequested) return;
                    branchesToDel.Add(branch);

                    for(int j=0; j<numberOfVertices; j++)
                    {
                        Branch newBranch = new Branch(branch);
                        if (newBranch.isVisited(j))
                        {
                            continue;
                        }

                        newBranch.addToPath(j);
                        if (newBranch.UpperBound < currentBestAnswer)
                        {
                            currentBestAnswer = (int)newBranch.UpperBound;
                            updater(newBranch.Answer);
                        }
                        branchesToAdd.Add(newBranch);
                    }
                    if (cancel.IsCancellationRequested) return;

                }

                foreach(Branch branch in branchesToDel)
                {
                    branches.Remove(branch);
                }

                foreach(Branch branch in branchesToAdd)
                {
                    branches.Add(branch);
                }
                if (cancel.IsCancellationRequested) return;
            }

            removeNotPerspectiveBranches(branches);

            Branch optimalBranch = null;
            double optimalWeight = 10e6;

            if (cancel.IsCancellationRequested) return;
            foreach (Branch branch in branches)
            {
                if (branch.Answer.Item1 < optimalWeight)
                {
                    optimalBranch = branch;
                    optimalWeight = branch.Answer.Item1;
                }
            }

            updater(optimalBranch.Answer);
            //Console.WriteLine("done");
        }

        public async Task<bool> branchAndBound(Updater updater, CancellationToken cancel)
        {
            this.updater = updater;
            setTSP(matrix, start);
            markedVertices[start] = true;

            await Task.Run(()=>BNB(cancel), cancel);
            return true;
        }
    }
}
