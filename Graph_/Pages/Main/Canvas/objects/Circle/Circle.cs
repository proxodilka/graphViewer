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
        public float r;
        PointF center;
        MutablePoint mutableCenter;
        public Color borderColor, fillColor, activeColor;

        public bool isFilled, isActive, isDragging;

        public Circle(Circle other)
        {
            center = other.center;
            r = other.r;
            isFilled = other.isFilled;
            mutableCenter = other.mutableCenter;
            borderColor = other.borderColor;
            isDragging = other.isDragging;
        }

        public Circle(float x, float y, float r, bool isFilled=false, bool isActive = false)
        {
            center = new PointF(x, y);
            this.r = r;
            this.isFilled = isFilled; this.isActive = isActive;
            mutableCenter = new MutablePoint(center);
            borderColor = Color.Black; fillColor = Color.Green; activeColor = Color.Red;
            isDragging = false;
        }

        public Circle(PointF _center, float r, bool isFilled = false, bool isActive = false)
        {
            center = _center;
            this.r = r;
            this.isFilled = isFilled; this.isActive = isActive;
            mutableCenter = new MutablePoint(center);
            borderColor = Color.Black; fillColor = Color.Green; activeColor = Color.Red;
            isDragging = false;
        }

        public PointF calcPointOnCircle(float value, bool isDegree = false)
        {
            if (isDegree) value *= (float)Math.PI / 180.0f;

            PointF ans = new PointF(center.X+r*(float)Math.Cos(value), center.Y+r*(float)Math.Sin(value));
            return ans;
        }

        public MutablePoint calcMutablePointOnCircle(float value, bool isDegree = false)
        {
            if (isDegree) value *= (float)Math.PI / 180.0f;

            return new MutablePoint(mutableCenter, new PointF(r * (float)Math.Cos(value), r * (float)Math.Sin(value)));
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static public Line getLineBetween(Circle from, Circle to)
        {
            //bool needToSwap = false;
            //if (from.Center.X > to.Center.X)
            //{
            //    needToSwap = true;
            //    Swap<Circle>(ref from, ref to);
            //}
            MutablePoint mutableStart = new MutablePoint(() =>
            {
                bool needToSwap = false;
                Circle _from = new Circle(from), _to = new Circle(to);
                if (from.Center.X >= to.Center.X)
                {
                    needToSwap = true;
                    Swap<Circle>(ref _from, ref _to);
                    if (from.Center.X == to.Center.X)
                    {
                        Console.WriteLine("equals");
                        _to.Center.X += 0.02f;
                    }
                }
                float devidor = (_to.MutableCenter.value.X - _from.MutableCenter.value.X);
                float ang1 = (float)Math.Atan((_to.MutableCenter.value.Y - _from.MutableCenter.value.Y) / (devidor==0?0.0001f:devidor)),
                ang2 = (float)Math.PI + ang1;
                return needToSwap?_to.calcPointOnCircle(ang2):_from.calcPointOnCircle(ang1);
            }),
            mutableEnd = new MutablePoint(() =>
            {
                bool needToSwap = false;
                Circle _from = new Circle(from), _to = new Circle(to);
                if (from.Center.X >= to.Center.X)
                {
                    needToSwap = true;
                    Swap<Circle>(ref _from, ref _to);
                    if (from.Center.X == to.Center.X)
                    {
                        Console.WriteLine("equals");
                        _to.Center.X += 0.02f;
                    }
                }
                float devidor = (_to.MutableCenter.value.X - _from.MutableCenter.value.X);
                float ang1 = (float)Math.Atan((_to.MutableCenter.value.Y - _from.MutableCenter.value.Y) / (devidor==0?0.0001f:devidor)),
                ang2 = (float)Math.PI + ang1;
                return !needToSwap ? _to.calcPointOnCircle(ang2) : _from.calcPointOnCircle(ang1);
            });

            //if (needToSwap)
            //{
            //    Swap<MutablePoint>(ref mutableStart, ref mutableEnd);
            //}
            Line edge = new Line(mutableStart, mutableEnd, Color.Black);

            return edge;
        }

        static public PointF calcPointOnCircle(float value, bool isDegree = false, float x=0, float y=0, float r=1)
        {
            if (isDegree) value *= (float)Math.PI / 180.0f;

            PointF ans = new PointF(x + r * (float)Math.Cos(value), y + r * (float)Math.Sin(value));
            return ans;
        }

        public RectangleF getAsRectangle()
        {
            RectangleF ans = new RectangleF(center.X - r, center.Y + r, 2 * r, 2 * r);
            return ans;
        }

        public bool isPointIn(PointF point)
        {
            return (center.X - point.X)* (center.X - point.X) + (center.Y - point.Y)* (center.Y - point.Y) <= r * r;
        }

        public void setNewCenter(PointF _center)
        {
            center = _center;
            mutableCenter.onChange(center);
        }

        public MutablePoint getCenterAsMutable()
        {
            return mutableCenter;
        }

        public float X { get { return center.X; } }
        public float Y { get { return center.Y; } }
        public float R { get { return r; } }
        public bool Dragging { get { return isDragging; } set { isDragging = Dragging; } }
        public ref PointF Center { get { return ref center; } }
        public MutablePoint MutableCenter { get { return mutableCenter; } }
    }
}
