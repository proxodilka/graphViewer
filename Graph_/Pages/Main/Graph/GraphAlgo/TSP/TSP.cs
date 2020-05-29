using matrixComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public delegate void Updater(Tuple<double, List<int>> ans);
    public partial class TSP
    {
        Updater updater;
        double INF = 10e9;
        //long overflowValue = (long)10e1;
        double[,] matrix;
        List<HashSet<int>> ways;
        List<int> ans;
        bool[] markedVertices;
        double currentOptimalWeight;
        int start;
        int numberOfVertices;

        public TSP(double[,] matrix)
        {

            setTSP(matrix);
            ways = new List<HashSet<int>>();
        }

        public TSP(double[,] matrix, int start)
        {

            setTSP(matrix, start);
        }

        public void setTSP(double[,] matrix)
        {
            this.matrix = makeComplete(matrix);
            start = 0;
            numberOfVertices = matrix.GetLength(0);
            currentOptimalWeight = INF;
            List<int> ans = new List<int>();
            markedVertices = new bool[numberOfVertices];
        }

        public void setTSP(double[,] matrix, int start)
        {
            setTSP(matrix);
            setStart(start);
        }

        public void setStart(int start)
        {
            this.start = start;
        }

        double[,] makeComplete(double[,] source)
        {
            double[,] ans = new double[source.GetLength(0), source.GetLength(1)];
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    ans[i, j] = source[i, j] == 0 ? INF : source[i, j];
                }
            }
            return ans;
        }


        static long[,] convertMatrixFromIntToLong(int[,] source)
        {
            long[,] answer = new long[source.GetLength(0), source.GetLength(1)];
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    answer[i, j] = source[i, j];
                }
            }
            return answer;
        }


        public double calcWayLength(List<int> way)
        {
            double result = 0;

            for (int i=0; i<way.Count-1; i++)
            {
                result += matrix[way[i], way[i + 1]];
            }

            return result;
        }
    }
}
