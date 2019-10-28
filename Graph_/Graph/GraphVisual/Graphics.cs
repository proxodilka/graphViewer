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
    delegate void eventListener(object sender);
    class GraphVisual
    {
        Graph graph;
        WFCanvas plot;
        Colors colors;
        int maxY, maxX;
        HashSet<int> activeVertices;
        Dictionary<int, Color> markedVertices;
        Dictionary<int, Node> nodes;
        bool animationStoped = false, hasActiveVertex=false;
        public bool isCanvasDirty { get; internal set; }
        public event eventListener didUpdate;

        bool isInited;

        public GraphVisual(PictureBox field, Graph _graph)
        {
            plot = new WFCanvas(field);
            graph = _graph;
            graph.edgeModified += onEdgesChanged;
            graph.vertexAdded += onVertexAdded;
            graph.vertexRemoved += onVertexRemoved;
            graph.rewrite += onRewrite;
            isInited = false;
            init();
        }

        public void init()
        {
            isCanvasDirty = false;
            animationStoped = false;
            hasActiveVertex = false;

            activeVertices = new HashSet<int>();
            markedVertices = new Dictionary<int, Color>();
            colors = new Colors();
            nodes = new Dictionary<int, Node>();
            onRewrite(nodes, new GraphEventArgs(graph.get().Keys.ToArray(), new int[0]));
            render();
            isInited = true;
        }

        private void onVertexAdded(object sender, GraphEventArgs e)
        {
            int vertexNumber = e.Vertices[0];
            nodes.Add(vertexNumber, new Node(vertexNumber, vertexNumber.ToString(), plot.getCurrentCenterCoords()));
            render();
        }

        private void onVertexRemoved(object sender, GraphEventArgs e)
        {
            nodes.Remove(e.Vertices[0]);
            render();
        }

        private void onRewrite(object sender, GraphEventArgs e)
        {
            reset(true);
            nodes.Clear();
            int ind = 0;
            foreach(int vertexNumber in e.Vertices)
            {
                //if (!nodes.ContainsKey(vertexNumber))
                    nodes.Add(vertexNumber, new Node(vertexNumber, vertexNumber.ToString(), getCoordsByN(ind)));
                ind++;
            }
            render(true);
        }

        private void onEdgesChanged(object sender, GraphEventArgs e)
        {
            render();
        }

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
            foreach(int vertexNumber in graph.get().Keys)
            {
                coords[vertexNumber] = getCoordsByN(ind);
                ind++;
            }
            setNodesCoords(coords);
        }

        private void drawVertices()
        {
            foreach(Node node in nodes.Values)
            {
                bool isNodeActive = activeVertices.Contains(node.ID);
                bool isNodeMarked = markedVertices.ContainsKey(node.ID);
                Color color = Color.White;
                if (isNodeMarked)
                    color = markedVertices[node.ID];

                node.draw(plot, isNodeActive, isNodeMarked, color);
            }
        }

        private void drawEdges()
        {
            var adjacenctList = graph.get();
            foreach(var pair in adjacenctList)
            {              
                int vertexNumber = pair.Key;
                int[] adjacenciesVertices = pair.Value.ToArray();

                foreach (int adjacencyVertex in adjacenciesVertices)
                {
                    if (adjacencyVertex <= vertexNumber)
                        continue;

                    Node startNode = nodes[vertexNumber],
                         endNode = nodes[adjacencyVertex];

                    Line edge = new Line(startNode.MutableCenter, endNode.MutableCenter, Color.Black);
                    plot.Lines.addLine(edge);
                }
            }
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

        async public Task<bool> animate(List<Tuple<int, int>> path)
        {
            reset();
            
            int delay = 600;
            foreach (var pair in path)
            {
                int vertex = pair.Item1, color = pair.Item2;
                setActive(vertex, Convert.ToBoolean(delay));
                await Task.Delay(delay);
                if (animationStoped) { animationStoped = false; delay = 0; }

                markVertex(vertex, color, Convert.ToBoolean(delay));
                await Task.Delay(delay);
                if (animationStoped) { animationStoped = false; delay = 0; }

            }
            isCanvasDirty = true;
            setActive(false);
            return true;
        }
        
        public void setNodesCoords(Dictionary<int, PointF> coordinates)
        {
            foreach(var pair in coordinates)
            {
                int vertexNumber = pair.Key;
                PointF newCenter = pair.Value;
                if (nodes.ContainsKey(vertexNumber))
                    nodes[vertexNumber].Center = newCenter;
            }
            render();
        }

        public Dictionary<int, PointF> getNodesCoords()
        {
            Dictionary<int, PointF> result = new Dictionary<int, PointF>();
            foreach(Node node in nodes.Values)
            {
                result.Add(node.ID, node.Center);
            }

            return result;
        }

        public string getNodesCoordsAsString()
        {
            string result = "coordinates //VERTEX_NUMBER : X Y\n";
            Dictionary<int, PointF> coordinates = getNodesCoords();
            foreach(var pair in coordinates)
            {
                result += $"{pair.Key} : {pair.Value.X} {pair.Value.Y}\n";
            }
            return result;
        }

        private void render(bool isResetCenter=false)
        {
            plot.reset();
            drawVertices();
            drawEdges();
            

            
            if (isResetCenter)
            {
                plot.setScale(calcScale());
                plot.resetCenter();
            }
                
  
            plot.render();
            didUpdate?.Invoke(this);
        }

        public void reset(bool withoutRender=false)
        {
            markedVertices.Clear();
            activeVertices.Clear();
            isCanvasDirty = false;
            animationStoped = false;
            hasActiveVertex = false;
            if (!withoutRender) render();
        }

        public void centrate()
        {
            render(true);
        }

        public void stopAnimation()
        {
            animationStoped = true;
        }

        public void setActive(int vertexNumber, bool rerender=true)
        {
            activeVertices.Clear();
            activeVertices.Add(vertexNumber);
            hasActiveVertex = true;
            if (rerender) render();
        }

        public void markVertex(int vertexNumber, int color = 1, bool rerender = true)
        {
            markedVertices[vertexNumber] = colors.getColor(color - 1);
            if (rerender) render();
        }

        public void setActive(bool x)
        {
            activeVertices.Clear();
            if (hasActiveVertex) render();
            hasActiveVertex = false;
        }
    }
}
