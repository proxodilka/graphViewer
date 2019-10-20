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

namespace Graph_
{
    class GraphVisual
    {
        Graph graph;
        WFCanvas plot;
        int maxY, maxX;
        HashSet<int> activeVertices, markedVertices;
        bool animationStoped = false;

        public GraphVisual(PictureBox field, Graph _graph)
        {
            plot = new WFCanvas(field);
            graph = _graph;
            graph.edgeModified += onEdgesChanged;
            graph.vertexModified += onVertexChanged;

            activeVertices = new HashSet<int>();
            markedVertices = new HashSet<int>();

            render();
        }

        private void onVertexChanged(object sender, GraphEventArgs e)
        {
            render();
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
                circle.fillColor = markedVertices.Contains(i)?Color.Green:Color.White;
                circle.isActive = activeVertices.Contains(i);

                plot.Circles.addCircle(circle, i);
                plot.Texts.addText((i).ToString(), coords.X, coords.Y);
                ind++;
            }
        }

        private void drawEdges()
        {
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

                    plot.Lines.addLine(startPoint, endPoint, Color.Black);
                }

            }
        }

        private int calcScale()
        {
            if (graph.verticesNumber == 0) return 1;
            int ans = graph.verticesNumber > 5 ? (220 / graph.verticesNumber) : (150 / graph.verticesNumber);
            return ans;
        }

        async public Task<bool> animate(List<int> path)
        {
            reset();
            foreach (int vertex in path)
            {
                activeVertices.Add(vertex);
                render();
                await Task.Delay(600);
                if (animationStoped) { animationStoped = false; return true; }

                markedVertices.Add(vertex);
                render();
                await Task.Delay(600);
                if (animationStoped) { animationStoped = false; return true; }

                activeVertices.Remove(vertex);
                render();
            }
            return true;
        }

        private void render()
        {
            plot.reset();
            drawVertecies();
            drawEdges();
            

            plot.setScale(calcScale());
  
            plot.render();
        }

        public void reset()
        {
            markedVertices.Clear();
            activeVertices.Clear();
            render();
        }

        public void stopAnimation()
        {
            animationStoped = true;
        }

        public void setActive(int vertexNumber)
        {
            activeVertices.Clear();
            activeVertices.Add(vertexNumber);
            render();
        }

        public void setActive(bool x)
        {
            activeVertices.Clear();
            render();
        }
    }
}
