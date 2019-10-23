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
        bool animationStoped = false, hasActiveVertex=false;
        public bool isCanvasDirty { get; internal set; }
        public event eventListener didUpdate;

        public GraphVisual(PictureBox field, Graph _graph)
        {
            plot = new WFCanvas(field);
            graph = _graph;
            graph.edgeModified += onEdgesChanged;
            graph.vertexModified += onVertexChanged;
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

            render();
        }

        private void onVertexChanged(object sender, GraphEventArgs e)
        {
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

        private void drawVertecies()
        {
            int ind = 0;
            foreach (var vertex in graph.get())
            {
                int i = vertex.Key;
                PointF coords = getCoordsByN(ind);

                Circle circle = new Circle(coords.X, coords.Y, 1, true);
                Color fillColor = markedVertices.ContainsKey(i) ? markedVertices[i] : Color.White;

                circle.fillColor = fillColor;
                circle.isActive = activeVertices.Contains(i);

                plot.Circles.addCircle(circle, i);
                plot.Texts.addText((i).ToString(), coords.X, coords.Y, Colors.getTextColorByBackground(fillColor));
                ind++;
            }
        }

        private void drawEdges()
        {
            int ind = 0;
            foreach (var vertex in graph.get())
            {
                int i = vertex.Key;
                HashSet<int> adj = vertex.Value;

                Circle start = plot.Circles.getCircle(i);

                foreach (int adj_vertex in adj)
                {
                    if (adj_vertex < i)
                        continue;
                    Circle end = plot.Circles.getCircle(adj_vertex);

                    PointF startPoint = new PointF(start.X, start.Y);
                    PointF endPoint = new PointF(end.X, end.Y);

                    if (Object.Equals(startPoint, endPoint))
                    {
                        int angleDif = 15;
                        float centerAngle = -2.0f * 180.0f * ind / graph.verticesNumber + 180;
                        PointF[] points = new PointF[5] { startPoint,
                                                          Circle.calcPointOnCircle(centerAngle+angleDif, true, start.X, start.Y, 1.75f),
                                                          Circle.calcPointOnCircle(centerAngle, true, start.X, start.Y, 2.25f),
                                                          Circle.calcPointOnCircle(centerAngle-angleDif, true, start.X, start.Y, 1.75f), endPoint };

                        plot.Curves.addCurve(points, Color.Black);
                    }
                    else
                        plot.Lines.addLine(startPoint, endPoint, Color.Black);
                }
                ind++;
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

        private void render(bool isResetCenter=false)
        {
            plot.reset();
            drawVertecies();
            drawEdges();
            

            
            if (isResetCenter)
            {
                plot.setScale(calcScale());
                plot.resetCenter();
            }
                
  
            plot.render();
            didUpdate?.Invoke(this);
        }

        public void reset()
        {
            markedVertices.Clear();
            activeVertices.Clear();
            isCanvasDirty = false;
            render();
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
