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
    public class MutablePoint
    {
        string mode;
        PointF _value, offset;
        Func<PointF> func;
        MutablePoint target;

        public MutablePoint(PointF __value)
        {
            _value = __value;
            mode = "pure";
        }

        public MutablePoint(MutablePoint _target, PointF fix_offset)
        {
            target = _target;
            offset = fix_offset;
            mode = "fix_offset";
        }

        public MutablePoint(MutablePoint _target, Func<PointF> _func)
        {
            target = _target;
            func = _func;
            mode = "dynamic_offset";
        }

        public MutablePoint(Func<PointF> _func)
        {
            func = _func;
            mode = "dynamic_point";
        }

        public void onChange(PointF newValue)
        {
            _value = newValue;
        }

        public PointF value { get 
            {
                switch (mode)
                {
                    case "pure": return _value; break;
                    case "dynamic_offset": { PointF offset = func(); return new PointF(target.value.X + offset.X, target.value.Y + offset.Y); break; }
                    case "fix_offset": return new PointF(target.value.X + offset.X, target.value.Y + offset.Y); break;
                    case "dynamic_point": return func();
                }
                return _value;
            } 
        }
    }
}
