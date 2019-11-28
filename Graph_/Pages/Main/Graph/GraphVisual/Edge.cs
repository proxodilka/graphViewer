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
    public class Edge
    {
        Node from, to;
        bool isDirected, hasPair, hasWeight;
        int orderInPair, weight;
        Line edge;
        Curve curve;

        private float offset { get { return (float)orderInPair / 2.0f; } }

        public Edge(Node from, Node to, bool hasWeight = false, bool isDirected=false, bool hasPair=false, int weight=0, int orderInPair = 1)
        {
            this.from = from;
            this.to = to;
            this.isDirected = isDirected;
            this.hasPair = hasPair;
            this.orderInPair = orderInPair==1?1:-1;
            this.hasWeight = hasWeight;
            this.weight = weight;
            edge = Circle.getLineBetween(from.Cirle, to.Cirle);
            curve = createCurve(edge.MutableStart, edge.MutableEnd);
        }

        public Edge(Node from, Node to, int weight) : this(from, to, true, false, false, weight) { }
        public Edge(Node from, Node to, bool isDirected) : this(from, to, false, isDirected) { }


        Curve createCurve(MutablePoint start, MutablePoint end)
        {
            MutablePoint center = new MutablePoint(() => { PointF result = getCenterOffsetByLine(edge, offset); return result; });
            List<MutablePoint> points = new List<MutablePoint>() { start, center, end };

            return new Curve(points);
        }

        PointF getCenterOffsetByLine(Line line, float offset)
        {
            PointF pureCenter = new PointF((line.MutableStart.value.X + line.MutableEnd.value.X) / 2.0f, (line.MutableStart.value.Y + line.MutableEnd.value.Y) / 2.0f);
            float angle = (float)Math.Atan((line.MutableEnd.value.Y - line.MutableStart.value.Y) / (line.MutableEnd.value.X - line.MutableStart.value.X));
            angle = -angle;
            PointF pOffset = new PointF(offset, offset);
            PointF result = new PointF(pOffset.X * (float)Math.Sin(angle), pOffset.Y * (float)Math.Cos(angle));
            result.X += pureCenter.X; result.Y += pureCenter.Y;

            return result;
        }

        public void draw(WFCanvas plot)
        {

            if (!hasPair || !isDirected)
            {
                Polygon arrow = getArrowByLine(edge);
                Text weigthText = getTextByLine(edge, (float)orderInPair/2.0f);
                if (isDirected)
                {
                    plot.Polygons.addPolygon(arrow);
                }
                if (hasWeight)
                {
                    plot.Texts.addText(weigthText);
                }
                plot.Lines.addLine(edge);
            }
            else
            {
                Polygon arrow = getArrowByCurve(curve);
                Text weigthText = getTextByLine(edge, 1.6f*offset);
                if (isDirected)
                {
                    plot.Polygons.addPolygon(arrow);
                }
                if (hasWeight)
                {
                    plot.Texts.addText(weigthText);
                }

                plot.Curves.addCurve(curve);   
            }
        }

        
        Text getTextByLine(Line edge, float offset = 1)
        {

            MutablePoint lineCenter = new MutablePoint(() =>
            {
                PointF result = getCenterOffsetByLine(edge, offset);
                return result;
                //float k = (edge.MutableEnd.value.Y - edge.MutableStart.value.Y) / (edge.MutableEnd.value.X - edge.MutableStart.value.X);
                //float c = (edge.MutableEnd.value.X * edge.MutableStart.value.Y - edge.MutableStart.value.X * edge.MutableEnd.value.Y) / (edge.MutableEnd.value.X - edge.MutableStart.value.X);
                //Func<float, float> offsetLineX = (float x) => k * x + c + (orderInPair == 1 ? 0.5f : -0.5f),
                //                   offsetLineY = (float y) => (y - c - (orderInPair == 1 ? 0.5f : -0.5f)) / k;
                //return new PointF((edge.MutableEnd.value.X + edge.MutableStart.value.X) / 2.0f, (offsetLineX(edge.MutableEnd.value.X) + offsetLineX(edge.MutableStart.value.X)) / 2.0f);
            });

            //MutablePoint textPosition = new MutablePoint(lineCenter, () =>
            //{
            //    return new PointF(orderInPair == 1 ? -0.25f : 0.25f, 0.5f);
            //});
            
            Text text = new Text(weight.ToString(), lineCenter, 0.5f, Color.Red);
            return text;
        }

        public float calcDeviations(PointF coords)
        {
            PointF p1 = edge.Start, p2 = edge.End;
            double k = (p2.Y - p1.Y) / (p2.X - p1.X);
            double c = (p2.X * p1.Y - p1.X * p2.Y) / (p2.X - p1.X);
            if (p1.X > p2.X || p1.Y > p2.Y)
            {
                Swap(ref p1, ref p2);
            }

            //if ((k > 0 && (coords.X < p1.X || coords.X > p2.X || coords.Y < p1.Y || coords.Y > p2.Y)) //if point not in reactangle
            // || (k < 0 && (coords.X > p1.X || coords.X < p2.X || coords.Y < p1.Y || coords.Y > p2.Y)))
            //    return 1000000;


            Func<double, double> f1 = (x) => x * k + c;

            return Math.Abs((float)f1(coords.X) - coords.Y);
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        Polygon getArrowByLine(Line edge)
        {

            float x1 = 0.18f, y1 = -0.4f,
                  x2 = -0.18f, y2 = -0.4f;
            return new Polygon(new List<MutablePoint>()
            {
                edge.MutableEnd,
                new MutablePoint(edge.MutableEnd, ()=> {
                    float _ang1 = (float)Math.Atan((to.MutableCenter.value.Y - from.MutableCenter.value.Y) / (to.MutableCenter.value.X - from.MutableCenter.value.X));
                    float _ang2 = ((float)Math.PI + _ang1) + (float)Math.PI/2.0f;
                    if (from.MutableCenter.value.X > to.MutableCenter.value.X)
                        _ang2+=(float)Math.PI;
                    return new PointF(x1*(float)Math.Cos(_ang2) - y1*(float)Math.Sin(_ang2), y1*(float)Math.Cos(_ang2) + x1*(float)Math.Sin(_ang2));
                }),
                new MutablePoint(edge.MutableEnd, ()=> {
                    float _ang1 = (float)Math.Atan((to.MutableCenter.value.Y - from.MutableCenter.value.Y) / (to.MutableCenter.value.X - from.MutableCenter.value.X));
                    float _ang2 = ((float)Math.PI + _ang1) + (float)Math.PI/2.0f;
                    if (from.MutableCenter.value.X > to.MutableCenter.value.X)
                        _ang2+=(float)Math.PI;
                    return new PointF(x2*(float)Math.Cos(_ang2) - y2*(float)Math.Sin(_ang2), y2*(float)Math.Cos(_ang2) + x2*(float)Math.Sin(_ang2));
                })
            }, Color.DimGray);
        }

        Polygon getArrowByCurve(Curve curve)
        {

            float x1 = 0.18f, y1 = -0.4f,
                  x2 = -0.18f, y2 = -0.4f;
            Line _edge = new Line(curve.MutableCenter, curve.MutableEnd, Color.Black);
            return new Polygon(new List<MutablePoint>()
            {
                _edge.MutableEnd,
                new MutablePoint(_edge.MutableEnd, ()=> {
                    float _ang1 = (float)Math.Atan((_edge.MutableEnd.value.Y - _edge.MutableStart.value.Y) / (_edge.MutableEnd.value.X - _edge.MutableStart.value.X));
                    float _ang2 = ((float)Math.PI + _ang1) + (float)Math.PI/2.0f;
                    if (_edge.MutableStart.value.X > _edge.MutableEnd.value.X)
                        _ang2+=(float)Math.PI;
                    return new PointF(x1*(float)Math.Cos(_ang2) - y1*(float)Math.Sin(_ang2), y1*(float)Math.Cos(_ang2) + x1*(float)Math.Sin(_ang2));
                }),
                new MutablePoint(_edge.MutableEnd, ()=> {
                    float _ang1 = (float)Math.Atan((_edge.MutableEnd.value.Y - _edge.MutableStart.value.Y) / (_edge.MutableEnd.value.X - _edge.MutableStart.value.X));
                    float _ang2 = ((float)Math.PI + _ang1) + (float)Math.PI/2.0f;
                    if (_edge.MutableStart.value.X > _edge.MutableEnd.value.X)
                        _ang2+=(float)Math.PI;
                    return new PointF(x2*(float)Math.Cos(_ang2) - y2*(float)Math.Sin(_ang2), y2*(float)Math.Cos(_ang2) + x2*(float)Math.Sin(_ang2));
                })
            }, Color.DimGray);
        }
    }
}
