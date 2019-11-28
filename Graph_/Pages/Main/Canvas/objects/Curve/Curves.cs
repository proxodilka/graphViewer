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
    public delegate double function(double arg);
    public class Curves
    {
        WFCanvas.WFCanvasContext context;
        List<Curve> curves;
        public Curves(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            curves = new List<Curve>();
        }

        public int addCurve(PointF[] points, Color? _color = null)
        {
            curves.Add(new Curve(points.ToList(), _color));
            return curves.Count - 1;
        }

        public int addCurve(Curve curve)
        {
            curves.Add(curve);
            return curves.Count - 1;
        }

        public void draw()
        {
            int scale = context.scale;
            PointF center = context.center;
            foreach (Curve curve in curves)
            {
                PointF[] points = curve.getPoints(point => new PointF(point.X * scale + center.X, center.Y - point.Y * scale));
                context.graph.DrawCurve(new Pen(curve.color, 2), points);
            }

        }

        public void clear()
        {
            curves.Clear();
        }
    }
    
}
