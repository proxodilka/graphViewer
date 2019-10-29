using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Graph_.Canvas;

namespace Graph_.GraphVisual_
{
    public partial class GraphVisual
    {
        
        private PointF getCoordsByN(int i)
        {
            int r = graph.verticesNumber, n = graph.verticesNumber;

            float angle = 2.0f * (float)Math.PI * i / n;
            float x = -r * (float)Math.Cos(angle), y = r * (float)Math.Sin(angle);

            return new PointF(x, y);
        }

        public void resetNodesCoords()
        {
            Dictionary<int, PointF> coords = new Dictionary<int, PointF>();

            int ind = 0;
            foreach (int vertexNumber in graph.get().Keys)
            {
                coords[vertexNumber] = getCoordsByN(ind);
                ind++;
            }
            setNodesCoords(coords);
        }

        public void setNodesCoords(Dictionary<int, PointF> coordinates)
        {
            foreach (var pair in coordinates)
            {
                int vertexNumber = pair.Key;
                PointF newCenter = pair.Value;
                if (nodes.ContainsKey(vertexNumber))
                    nodes[vertexNumber].Center = newCenter;
            }
            render();
        }

        public void setNodeCoords(int nodeId, PointF coordinates)
        {
            if (nodes.ContainsKey(nodeId))
                nodes[nodeId].Center = coordinates;
            render();
        }

        public int getNodeByCoords(PointF coordinates)
        {
            foreach(Node node in nodes.Values)
            {
                if (node.isPointIn(coordinates))
                    return node.ID;
            }
            return -1;
        }

        public Tuple<int, int> getEdgeByCoords(PointF coords)
        {
            if (getNodeByCoords(coords) != -1)
                return null;

            var adjacenctList = graph.get();
            foreach (var pair in adjacenctList)
            {
                int vertexNumber = pair.Key;
                int[] adjacenciesVertices = pair.Value.ToArray();

                foreach (int adjacencyVertex in adjacenciesVertices)
                {
                    if (adjacencyVertex == vertexNumber)
                        continue;

                    Node startNode = nodes[vertexNumber],
                         endNode = nodes[adjacencyVertex];

                    PointF p1 = startNode.Center,
                           p2 = endNode.Center;

                    double k = (p2.Y - p1.Y) / (p2.X - p1.X);
                    double c = (p2.X * p1.Y - p1.X * p2.Y) / (p2.X - p1.X);
                    if (p1.X>p2.X || p1.Y > p2.Y)
                    {
                        Swap(ref p1, ref p2);
                    }

                    if  ((k > 0 && (coords.X < p1.X || coords.X > p2.X || coords.Y < p1.Y || coords.Y > p2.Y))
                      || (k < 0 && (coords.X > p1.X || coords.X < p2.X || coords.Y < p1.Y || coords.Y > p2.Y))) 
                        continue;

                    int delta = 2;
                    Func<double, double> f1 = (x) => x * k + c + delta,
                                         f2 = (x) => x * k + c + - delta;

                    if (coords.Y<=f1(coords.X) && coords.Y >= f2(coords.X))
                    {
                        return new Tuple<int, int>(vertexNumber, adjacencyVertex);
                    }
                }
            }
            return null;
        }

        public Dictionary<int, PointF> getNodesCoords()
        {
            Dictionary<int, PointF> result = new Dictionary<int, PointF>();
            foreach (Node node in nodes.Values)
            {
                result.Add(node.ID, node.Center);
            }

            return result;
        }

        public string getNodesCoordsAsString()
        {
            string result = "coordinates //VERTEX_NUMBER : X Y\n";
            Dictionary<int, PointF> coordinates = getNodesCoords();
            foreach (var pair in coordinates)
            {
                result += $"{pair.Key} : {pair.Value.X} {pair.Value.Y}\n";
            }
            return result;
        }

        private int calcScale()
        {
            int baseCoef = 220;
            while (baseCoef < graph.verticesNumber)
                baseCoef *= 2;
            if (graph.verticesNumber == 0) return 1;
            int ans = graph.verticesNumber > 5 ? (baseCoef / graph.verticesNumber) : (150 / graph.verticesNumber);
            return ans;
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
