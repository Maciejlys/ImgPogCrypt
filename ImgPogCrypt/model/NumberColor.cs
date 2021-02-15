using System;
using System.Drawing;

namespace ImgPogCrypt.model
{
    public class NumberColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public NumberColor(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static NumberColor fromColor(Color color)
        {
            return new NumberColor(
                Convert.ToInt32(color.R),
                Convert.ToInt32(color.G),
                Convert.ToInt32(color.B),
                Convert.ToInt32(color.A)
            );
        }

        public Color toColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

        public int GetSumValue()
        {
            return R + G + B;
        }

        public int SubtractNumberColor(NumberColor color)
        {
            return Math.Abs(this.GetSumValue() - color.GetSumValue());
        }
    }
}