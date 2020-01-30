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
        private void drawVertices()
        {
            foreach (Node node in nodes.Values)
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
            var adjacenctList = graph.getWeighted();
            foreach (var pair in adjacenctList)
            {
                int vertexNumber = pair.Key;
                //int[] adjacenciesVertices = pair.Value.ToArray();

                foreach (var adjacencyVertex in pair.Value)
                {

                    Node startNode = nodes[vertexNumber],
                         endNode = nodes[adjacencyVertex.Key];

                    Edge edge = new Edge(startNode, endNode, isWeighted, isDirected, graph.hasEdge(endNode.ID, startNode.ID), Math.Round(adjacencyVertex.Value, 2).ToString(), startNode.ID<endNode.ID?1:2);
                    if (isShowingPath)
                    {
                        //(a, b) => a.Item1 == b.Item1 && a.Item2 == b.Item2)
                        Tuple<int, int> edgeAsTuple = new Tuple<int, int>(startNode.ID, endNode.ID);
                        if (markedEdges.Contains(edgeAsTuple))
                        {
                            edge.Color = Color.Blue;
                        }
                        else
                        {
                            edge.isHidden = true;
                        }
                    }


                    edge.draw(plot);
                }
            }
        }

        public void drawBindedLines()
        {
            foreach(Line line in bindedLines.Values)
            {
                plot.Lines.addLine(line);
            }
        }

        async public Task<bool> animate(List<Tuple<int, int>> path)
        {
            //reset();

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

        public void stopAnimation()
        {
            animationStoped = true;
        }

        public void setPath(List<int> path)
        {
            isShowingPath = true;
            markedEdges.Clear();
            markedVertices.Clear();
            for (int i=0; i<path.Count-1; i++)
            {
                markedEdges.Add(new Tuple<int, int>(path[i], path[i + 1]));
                markedVertices.Add(path[i], Color.Blue);
            }
            render();
        }

    }
}
