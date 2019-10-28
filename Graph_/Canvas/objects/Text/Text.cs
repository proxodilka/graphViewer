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

    public class Text
    {
        bool isCenterMutable;
        string text;
        int fontSize;
        MutablePoint mutableCenter;
        PointF center;
        Color color;

        private void initNulls(int? _fontSize, Color? _color)
        {
            color = _color ?? Color.Black;
            fontSize = _fontSize ?? 16;
        }

        public Text(string _text, PointF _center, int? _fontSize, Color? _color)
        {
            initNulls(_fontSize, _color);
            center = _center;
            text = _text;
            isCenterMutable = false;
        }

        public Text(string _text, MutablePoint _center, int? _fontSize, Color? _color)
        {
            initNulls(_fontSize, _color);
            mutableCenter = _center;
            text = _text;
            isCenterMutable = true;
        }


        public Rectangle getAsTranslatedRectangle(int scale, PointF center)
        {
            int fontSize = this.fontSize * scale;
            float x = Center.X * scale + center.X;
            float y = center.Y - Center.Y * scale;

            return new Rectangle((int)x - fontSize * text.Length / 2, (int)y - fontSize / 2, fontSize * text.Length, fontSize);
        }

        public Font getCalcedFont(int scale)
        {
            return new Font("arial", fontSize*scale <= 0 ? 0.000001f : fontSize*scale, GraphicsUnit.Pixel);
        }

        public Font Font { get { return new Font("arial", 16/*fontSize <= 0 ? 0.000001f : fontSize*/, GraphicsUnit.Pixel); } }
        public Color Color { get { return color; } set { color = value; } }

        public String String { get { return text; } }
        public PointF Center
        {
            get
            {
                if (isCenterMutable) return mutableCenter.value;
                return center;
            }
        }
    }
}
