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

        public void setNodesCoords(Dictionary<int, PointF> coordinates, bool centrateAll=false)
        {
            foreach (var pair in coordinates)
            {
                int vertexNumber = pair.Key;
                PointF newCenter = pair.Value;
                if (nodes.ContainsKey(vertexNumber))
                    nodes[vertexNumber].Center = newCenter;
            }

            if (centrateAll)
            {
                Dictionary<int, Node> nodesWithoutCoords = new Dictionary<int, Node>();
                foreach(Node node in nodes.Values)
                {
                    if (!coordinates.ContainsKey(node.ID))
                    {
                        nodesWithoutCoords.Add(node.ID, node);
                    }
                }
                foreach (int id in nodesWithoutCoords.Keys)
                    nodes.Remove(id);

                PointF center = getPreferedCenter();
                foreach (Node node in nodesWithoutCoords.Values)
                {
                    node.Center = center;
                    nodes.Add(node.ID, node);
                }
            }

            render(true);
        }

        /// <summary>
        /// Detects if given point belongs to any node-circle
        /// Returns vertex number or -1 if not belong
        /// </summary>
        public void setNodeCoords(int nodeId, PointF coordinates, bool withoutRender=false)
        {
            if (nodes.ContainsKey(nodeId))
                nodes[nodeId].Center = coordinates;
            if (!withoutRender) render();
        }

        /// <summary>
        /// Detects if given point belongs to any node-circle
        /// Returns vertex number or -1 if not belong
        /// </summary>
        public int getNodeByCoords(PointF coordinates)
        {
            foreach(Node node in nodes.Values)
            {
                if (node.isPointIn(coordinates))
                    return node.ID;
            }
            return -1;
            //getEdgeByCoords()
        }

        /// <summary>
        /// Detects if given point belongs to any edge-line
        /// </summary>
        /// <returns>Returns Tuple of 'from' and 'to' vertices numbers or null if not belong</returns>
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
            return getPreferedScale();
        }

        /// <summary>
        /// Returns viewport bounds according to nodes positions, 0 - left; 1 - right; 2 - top; 3 - bottom
        /// </summary>
        public PointF[] getBounds()
        {
            PointF[] result = new PointF[4];
            bool[] isInit = new bool[4] { false, false, false, false };
            foreach(Node node in nodes.Values)
            {
                if (node.Center.X<result[0].X || !isInit[0])
                {
                    isInit[0] = true;
                    result[0] = node.Center;
                }

                if (node.Center.X > result[1].X || !isInit[1])
                {
                    isInit[1] = true;
                    result[1] = node.Center;
                }

                if (node.Center.Y > result[2].Y || !isInit[2])
                {
                    isInit[2] = true;
                    result[2] = node.Center;
                }

                if (node.Center.Y < result[3].Y || !isInit[3])
                {
                    isInit[3] = true;
                    result[3] = node.Center;
                }

            }

            return result;
        }

        /// <summary>
        /// Returns scale value at which canvas can display all nodes without overflow
        /// </summary>
        public int getPreferedScale()
        {
            PointF[] bounds = getBounds();
            int ans = 50;
            while (ans > 1)
            {
                PointF coords1 = plot.translateRelatedCoordsToCurrentCenter(new PointF(bounds[0].X+2, bounds[2].Y+2), ans);
                PointF coords2 = plot.translateRelatedCoordsToCurrentCenter(new PointF(bounds[1].X+2, bounds[3].Y+2), ans);
                if (coords1.X > 0 && coords1.Y > 0 && coords2.X > 0 && coords2.Y > 0
                 && coords1.X < plot.W && coords1.Y < plot.H && coords2.X < plot.W && coords2.Y < plot.H)
                    return ans;
                ans--;
            }
            return ans;
        }

        /// <summary>
        /// Returns position in relative coordinates
        /// </summary>
        public PointF getPreferedCenter()
        {
            PointF[] bounds = getBounds();
            PointF bottomLeft = new PointF(bounds[0].X, bounds[3].Y),
                   topRight   = new PointF(bounds[1].X, bounds[2].Y);

            PointF center = new PointF((bottomLeft.X + topRight.X) / 2.0f,
                                       (bottomLeft.Y + topRight.Y) / 2.0f);

            return center;
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
