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
        private List<Tuple<Color, List<PointF>>> curves;
        private List<Tuple<Color, PointF[]>> staticPoints;
        private List<Tuple<Color, function>> curveFunctions;

        public Curves(WFCanvas.WFCanvasContext context)
        {
            this.context = context;
            this.curves = new List<Tuple<Color, List<PointF>>>();
            this.staticPoints = new List<Tuple<Color, PointF[]>>();
            this.curveFunctions = new List<Tuple<Color, function>>();
        }

        public int addCurveFunction(function value = null, Color? _color = null)
        {
            if (value == null)
            {
                return -1;
            }

            Color color = _color ?? Color.Red;
            curveFunctions.Add(new Tuple<Color, function>(color, value));
            return curveFunctions.Count() - 1;
        }

        public int addCurve(PointF[] points, Color? _color = null)
        {
            Color color = _color ?? Color.Red;
            staticPoints.Add(new Tuple<Color, PointF[]>(color, points));
            return staticPoints.Count - 1;
        }

        public bool changeCurveFunction(int id, function value, Color? _color = null)
        {
            if (id >= curveFunctions.Count())
            {
                return false;
            }

            Color color = _color ?? curveFunctions[id].Item1;
            curveFunctions[id] = new Tuple<Color, function>(color, value);
            return true;
        }

        private void calcFunctions()
        {
            curves.Clear();
            foreach (Tuple<Color, function> currentCurveFunction in curveFunctions)
            {
                calcFunction(currentCurveFunction);
            }
        }

        private void calcFunction(Tuple<Color, function> currentCurveFunction)
        {
            Color color = currentCurveFunction.Item1;
            function calc = currentCurveFunction.Item2;

            float step = 0.5f;
            float i = 0;
            while (i < context.w * context.scale + 1)
            {
                List<PointF> cureCurve = new List<PointF>();
                for (; i < context.w * context.scale + 1; i += step)
                {
                    float value = context.center.Y - (float)calc(i / context.scale - context.center.X / context.scale) * context.scale;
                    if (value > 3 * context.h || value < -3 * context.h)
                    {
                        i += step;
                        break;
                    }
                    cureCurve.Add(new PointF(i, value));
                }
                if (cureCurve.Count > 1)
                    curves.Add(new Tuple<Color, List<PointF>>(color, cureCurve));
            }
        }

        public void draw()
        {
            calcFunctions();
            foreach (Tuple<Color, List<PointF>> curveSource in curves)
            {
                Color color = curveSource.Item1;
                List<PointF> curve = curveSource.Item2;

                context.graph.DrawCurve(new Pen(color, 2), curve.ToArray());
            }

            foreach (Tuple<Color, PointF[]> curveSource in staticPoints)
            {
                int scale = context.scale;
                PointF center = context.center;

                Color color = curveSource.Item1;
                PointF[] curve = curveSource.Item2.Select(point=>new PointF(point.X*scale+center.X, center.Y-point.Y*scale)).ToArray();

                context.graph.DrawCurve(new Pen(color, 2), curve);
            }

        }

        public void clear()
        {
            curves.Clear();
            staticPoints.Clear();
            curveFunctions.Clear();
        }
    }
    
}
