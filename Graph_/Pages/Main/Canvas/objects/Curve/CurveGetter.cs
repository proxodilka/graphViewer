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
        public PointF[] getPoints(Func<PointF, PointF> translator)
        {
            int pointsSize;
            PointF[] ans = null;
            switch (mode)
            {
                case "static":
                    {
                        ans = new PointF[points.Count];
                        for (int i = 0; i < points.Count; i++)
                        {
                            ans[i] = translator(points[i]);
                        }

                    }
                    break;
                case "mutable":
                    {
                        ans = new PointF[mutablePoints.Count];
                        for (int i = 0; i < mutablePoints.Count; i++)
                        {
                            ans[i] = translator(mutablePoints[i].value);
                        }
                    }
                    break;
            }

            return ans;
        }

        public PointF Start
        {
            get
            {
                PointF point = new PointF();
                switch (mode)
                {
                    case "static": point = points[0]; break;
                    case "mutable": point = mutablePoints[0].value; break;
                }
                return point;
            }
        }

        public PointF End
        {
            get
            {
                PointF point = new PointF();
                switch (mode)
                {
                    case "static": point = points[points.Count - 1]; break;
                    case "mutable": point = mutablePoints[points.Count - 1].value; break;
                }
                return point;
            }
        }

        public PointF Center
        {
            get
            {
                PointF point = new PointF();
                switch (mode)
                {
                    case "static": point = points[points.Count / 2]; break;
                    case "mutable": point = mutablePoints[points.Count / 2].value; break;
                }
                return point;
            }
        }

        public MutablePoint MutableStart
        {
            get { return mutablePoints[Math.Min(0, mutablePoints.Count-1)]; }
        }

        public MutablePoint MutableEnd
        {
            get { return mutablePoints[Math.Max(0, mutablePoints.Count-1)]; }
        }

        public MutablePoint MutableCenter
        {
            get { return mutablePoints[Math.Max(0, (mutablePoints.Count-1)/2)]; }
        }
    }
}
