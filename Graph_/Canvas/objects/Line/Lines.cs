using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_
{
    public class Lines
    {
        WFCanvas.WFCanvasContext context;
        private List<Tuple<Color, Tuple<PointF, PointF>>> lines;
        private List<Line> properLines;

        public Lines(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.lines = new List<Tuple<Color, Tuple<PointF, PointF>>>();
            properLines = new List<Line>();
        }

        public int addLine(Line line)
        {
            properLines.Add(line);
            return properLines.Count() - 1;
        }

        public int addLine(PointF start, PointF end, Color? _color = null)
        {
            Color color = _color ?? Color.Red;

            lines.Add(new Tuple<Color, Tuple<PointF, PointF>>(color,
                      new Tuple<PointF, PointF>(start, end)));

            return lines.Count() - 1;
        }

        public bool changeLine(int id, PointF start, PointF end, Color? _color = null)
        {
            if (id >= lines.Count())
            {
                return false;
            }

            Color color = _color ?? lines[id].Item1;

            lines[id] = new Tuple<Color, Tuple<PointF, PointF>>(color, new Tuple<PointF, PointF>(start, end));
            return true;
        }

        public int addLineY(float Y_value, Color? _color = null)
        {
            
            Color color = _color ?? Color.Black;
            return addLine(new PointF(-context.w, Y_value), new PointF(context.w, Y_value), color);
        }

        public bool changeLineY(int id, float Y_value, Color? _color = null)
        {
            //Color color = _color ?? Color.Black;
            return changeLine(id, new PointF(-context.w, Y_value), new PointF(context.w, Y_value));
        }

        public void draw()
        {
            int scale = context.scale, w = context.w, h = context.h;
            PointF center = context.center;

            foreach (Tuple<Color, Tuple<PointF, PointF>> line in lines)
            {
                Color color = line.Item1;
                PointF start = line.Item2.Item1, end = line.Item2.Item2;

                start.X = start.X * scale + center.X; start.Y = center.Y - start.Y * scale;
                end.X = end.X * scale + center.X; end.Y = center.Y - end.Y * scale;

                //if (start.Y > 2 * h || start.Y < -2 * h || end.Y > 2 * h || end.Y < -2 * h)
                //    continue;
                context.graph.DrawLine(new Pen(color, 2), start, end);
            }

            foreach (Line line in properLines)
            {
                PointF lineStart = line.Start,
                       lineEnd   = line.End,
                       start = new PointF(lineStart.X*scale+center.X, center.Y - lineStart.Y*scale),
                       end   = new PointF(lineEnd.X * scale + center.X, center.Y - lineEnd.Y * scale);
                context.graph.DrawLine(new Pen(line.Color, 2), start, end);
            }
        }

        public void clear()
        {
            lines.Clear();
            properLines.Clear();
        }
    }
}
