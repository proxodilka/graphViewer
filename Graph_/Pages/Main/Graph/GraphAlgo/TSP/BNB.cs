using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class TSP
    {
        struct Branch
        {
            long lowerBound, upperBound, currentWeight;
            int position;
            List<int> way;

            public long LowerBound { get { return lowerBound; } set { lowerBound = value; } }
            public long UpperBound { get { return upperBound; } set { upperBound = value; } }
            public int Position { get { return position; } set { position = value; } }
            public long CurrentWeight { get { return currentWeight; } set { currentWeight = value; } }
            public List<int> Way { get { return way; } }

            public Branch(List<int> way, long lowerBound, long upperBound, long currentWeight, int position)
            {
                this.way = way;
                this.lowerBound = lowerBound;
                this.upperBound = upperBound;
                this.position = position;
                this.currentWeight = currentWeight;
            }

            public Branch(Branch other)
            {
                lowerBound = other.lowerBound;
                upperBound = other.upperBound;
                position = other.position;
                currentWeight = other.currentWeight;
                way = new List<int>(other.way);
            }
        }

        long getLowerBound(Branch branch)
        {
            long weight = branch.CurrentWeight;
            bool[] markedVertices = new bool[numberOfVertices];
            foreach (int vertex in branch.Way)
            {
                markedVertices[vertex] = true;
            }
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                if (markedVertices[i] && i!=start)
                {
                    continue;
                }
                long minWeight = INF;
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    minWeight = Math.Min(minWeight, matrix[i, j]);
                }
                weight += minWeight;
            }
            return weight;
        }

        long getUpperBound(Branch branch)
        {
            var result = greedyWrapper(branch.Way, branch.CurrentWeight, branch.Position, branch.Way.Count-1);
            return result.Item1;
        }

        Branch BNB(HashSet<Branch> branches=null)
        {
            HashSet<Branch> newBranches = new HashSet<Branch>();
            long minUpperBound = branches.Min((x) => x.UpperBound);
            branches.RemoveWhere((x) => x.LowerBound > minUpperBound);
            bool isFindingLastEdge = false;
            if (branches.First().Way.Count == numberOfVertices)
            {
                foreach (Branch branch in branches)
                {
                    Branch branchToAdd = new Branch(branch);
                    branchToAdd.Way.Add(start);
                    branchToAdd.CurrentWeight += matrix[branchToAdd.Position, start];
                    newBranches.Add(branchToAdd);
                }
                return BNB(newBranches);
            }
            if (branches.First().Way.Count == numberOfVertices+1)
            {
                Branch branchWithMinWeight = new Branch(new List<int>(), 0, 0, INF, 0);
                foreach(Branch branch in branches)
                {
                    if (branch.CurrentWeight < branchWithMinWeight.CurrentWeight)
                    {
                        branchWithMinWeight = new Branch(branch);
                    }
                }
                return branchWithMinWeight;
            }

            foreach (Branch branch in branches)
            {
                for(int i=0; i<matrix.GetLength(0); i++)
                {
                    if (branch.Way.Contains(i) || i == branch.Position)
                    {
                        continue;
                    }
                    Branch branchToAdd = new Branch(branch);

                    branchToAdd.Way.Add(i);
                    branchToAdd.Position = i;
                    branchToAdd.CurrentWeight += matrix[branch.Position, i];

                    branchToAdd.LowerBound = getLowerBound(branchToAdd);
                    branchToAdd.UpperBound = getUpperBound(branchToAdd);

                    newBranches.Add(branchToAdd);
                }
            }

            return BNB(newBranches);
        }

        public Tuple<int, List<int>> branchAndBound()
        {
            setTSP(matrix, start);
            markedVertices[start] = true;

            Branch ans = BNB(new HashSet<Branch>() { new Branch(new List<int>(){start}, 0, 0, 0, 0)  });
            return (ans.CurrentWeight >= INF) ? null : new Tuple<int, List<int>>((int)ans.CurrentWeight, ans.Way);
        }
    }
}
