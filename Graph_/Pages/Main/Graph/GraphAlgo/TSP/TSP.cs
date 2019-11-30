using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public delegate void Updater(Tuple<int, List<int>> ans);
    public partial class TSP
    {
        Updater updater;
        long INF = (long)10e9;
        //long overflowValue = (long)10e1;
        long[,] matrix;
        List<HashSet<int>> ways;
        List<int> ans;
        bool[] markedVertices;
        long currentOptimalWeight;
        int start;
        int numberOfVertices;

        public TSP(int[,] matrix)
        {

            setTSP(convertMatrixFromIntToLong(matrix));
            ways = new List<HashSet<int>>();
        }

        public TSP(int[,] matrix, int start) : this(matrix)
        {

            setStart(start);
        }

        public void setTSP(long[,] matrix)
        {
            this.matrix = makeComplete(matrix);
            start = 0;
            numberOfVertices = matrix.GetLength(0);
            currentOptimalWeight = INF;
            List<int> ans = new List<int>();
            markedVertices = new bool[numberOfVertices];
        }

        public void setTSP(long[,] matrix, int start)
        {
            setTSP(matrix);
            setStart(start);
        }

        public void setStart(int start)
        {
            this.start = start;
        }

        long[,] makeComplete(long[,] source)
        {
            long[,] ans = new long[source.GetLength(0), source.GetLength(1)];
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
    }
}
