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

namespace Graph_.Canvas
{
    
    class Colors
    {

        List<Color> colors;
        public Colors()
        {
            colors = new List<Color>();
            generateColors();
        }

        public Color getColor(int n)
        {
            return colors[n % colors.Count];
        }

        static public Color getTextColorByBackground(Color bkgColor)
        {
            Color white = Color.White, black = Color.Black;
            double blackToBkg = calcContrastRatio(black, bkgColor),
                   whiteToBkg = calcContrastRatio(white, bkgColor);

            return blackToBkg > whiteToBkg ? black : white;
        }

        static public double calcContrastRatio(Color first, Color second)
        {
            double L1 = calcRelativeLuminance(first),
                   L2 = calcRelativeLuminance(second);

            if (L1 < L2) Swap<double>(ref L1, ref L2);
            return (L1 + 0.05) / (L2 + 0.05);
        }

        static public double calcRelativeLuminance(Color color)
        {
            double r = color.R, g = color.G, b = color.B;
            r /= 255.0; g /= 255.0; b /= 255.0;

            if (r <= 0.03928) r /= 12.92; else r = Math.Pow((r + 0.055) / 1.055, 2.4);
            if (g <= 0.03928) g /= 12.92; else g = Math.Pow((g + 0.055) / 1.055, 2.4);
            if (r <= 0.03928) b /= 12.92; else b = Math.Pow((b + 0.055) / 1.055, 2.4);

            return 0.2126 * r + 0.7152 * g + 0.0722f * b;
        }

        private void generateColors()
        {
            int val = 255;
            while (val!=0)
            {
                colors.Add(Color.FromArgb(0, 0, val));
                colors.Add(Color.FromArgb(0, val, 0));
                colors.Add(Color.FromArgb(val, 0, 0));

                colors.Add(Color.FromArgb(0, val, val));
                colors.Add(Color.FromArgb(val, val, 0));
                colors.Add(Color.FromArgb(val, 0, val));
                val /= 2;
            }
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

    }
}
