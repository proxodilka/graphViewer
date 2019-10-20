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

        public Lines(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.lines = new List<Tuple<Color, Tuple<PointF, PointF>>>();
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

        //public int addLineY(float Y_value, Color? _color = null)
        //{
        //    Color color = _color ?? Color.Black;
        //    function f = delegate (double x) { return Y_value; };
        //    addCurveFunction(f, color);
        //    return curveFunctions.Count() - 1;
        //}

        //public bool changeLineY(int id, float Y_value, Color? _color = null)
        //{
        //    function f = delegate (double x) { return Y_value; };
        //    return changeCurveFunction(id, f, _color);
        //}

        public void draw()
        {
            foreach (Tuple<Color, Tuple<PointF, PointF>> line in lines)
            {
                Color color = line.Item1;
                PointF start = line.Item2.Item1, end = line.Item2.Item2;

                start.X = start.X * context.scale + context.center.X; start.Y = context.center.Y - start.Y * context.scale;
                end.X = end.X * context.scale + context.center.X; end.Y = context.center.Y - end.Y * context.scale;


                context.graph.DrawLine(new Pen(color, 2), start, end);
            }
        }

        public void clear()
        {
            lines.Clear();
        }
    }
}
