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

namespace Graph_
{
    
    public class Line
    {
        bool isMutableStart, isMutableEnd;
        MutablePoint mutableStart, mutableEnd;
        PointF start, end;
        Color color;

        private void initColor(Color? _color)
        {
            Color __color = _color ?? Color.Black;
            color = __color;
        }

        public Line(PointF _start, PointF _end, Color? _color)
        {
            initColor(_color);
            start = _start;
            end = _end;
            isMutableStart = isMutableEnd = false;
        }
        
        public Line(MutablePoint _start, PointF _end, Color? _color)
        {
            initColor(_color);
            mutableStart = _start;
            end = _end;
            isMutableStart = true;
            isMutableEnd = false;
        }

        public Line(PointF _start, MutablePoint _end, Color? _color)
        {
            initColor(_color);
            start = _start;
            mutableEnd = _end;
            isMutableStart = false;
            isMutableEnd = true;
        }

        public Line(MutablePoint _start, MutablePoint _end, Color? _color)
        {
            initColor(_color);
            mutableStart = _start;
            mutableEnd = _end;
            isMutableStart = isMutableEnd = true;
        }

        public PointF Start { 
            get
            {
                if (isMutableStart) return mutableStart.value;
                return start;
            } 
        }

        public PointF End
        {
            get
            {
                if (isMutableEnd) return mutableEnd.value;
                return end;
            }
        }

        public MutablePoint MutableStart { get { return mutableStart; } }
        public MutablePoint MutableEnd { get { return mutableEnd; } }

        public Color Color { get { return color; } set { color = value; } }
    }
}
