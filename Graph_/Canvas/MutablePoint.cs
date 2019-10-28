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
        PointF _value;

        public MutablePoint(PointF __value)
        {
            _value = __value;
        }

        public void onChange(PointF newValue)
        {
            _value = newValue;
        }

        public PointF value { get { return _value; } }
    }
}
