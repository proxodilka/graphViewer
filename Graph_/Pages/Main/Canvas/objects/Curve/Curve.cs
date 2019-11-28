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
    public partial class Curve
    {
        const int defaultUpperBound = 1000;

        List<PointF> points;
        List<MutablePoint> mutablePoints;
        Func<double, double> function;
        public Color color = Color.Black;
        string mode;
        int calcedUpperBound;

        public Curve(List<PointF> points)
        {
            this.points = points;
            mode = "static";
        }

        public Curve(List<MutablePoint> points)
        {
            this.mutablePoints = points;
            mode = "mutable";
        }

        public Curve(Func<double, double> function)
        {
            this.function = function;
            mode = "function";
        }

        public Curve(List<PointF> points, Color? color=null) : this(points)
        {
            this.color = color??Color.Black;
        }

        public Curve(List<MutablePoint> points, Color? color = null) : this(points)
        {
            this.color = color ?? Color.Black;
        }

        public Curve(Func<double, double> function, Color? color = null) : this(function)
        {
            this.color = color ?? Color.Black;
        }

    }
}
