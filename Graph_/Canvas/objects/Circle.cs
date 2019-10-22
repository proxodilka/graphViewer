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
    public class Circle
    {
        float x, y, r;
        public Color borderColor, fillColor, activeColor;

        public bool isFilled, isActive;

        public Circle(float x, float y, float r, bool isFilled=false, bool isActive = false)
        {
            this.x = x; this.y = y; this.r = r;
            this.isFilled = isFilled; this.isActive = isActive;

            borderColor = Color.Black; fillColor = Color.Green; activeColor = Color.Red;
        }

        public PointF calcPointOnCircle(float value, bool isDegree = false)
        {
            if (isDegree) value *= (float)Math.PI / 180.0f;

            PointF ans = new PointF(x+r*(float)Math.Cos(value), y+r*(float)Math.Sin(value));
            return ans;
        }

        static public PointF calcPointOnCircle(float value, bool isDegree = false, float x=0, float y=0, float r=1)
        {
            if (isDegree) value *= (float)Math.PI / 180.0f;

            PointF ans = new PointF(x + r * (float)Math.Cos(value), y + r * (float)Math.Sin(value));
            return ans;
        }

        public RectangleF getAsRectangle()
        {
            RectangleF ans = new RectangleF(x - r, y + r, 2 * r, 2 * r);
            return ans;
        }

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float R { get { return r; } }
    }
}
