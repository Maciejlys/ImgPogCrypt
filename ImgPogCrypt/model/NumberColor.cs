using System;
using System.Drawing;

namespace ImgPogCrypt.model
{
    public class NumberColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public NumberColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static NumberColor fromColor(Color color)
        {
            return new NumberColor(
                Convert.ToInt32(color.R),
                Convert.ToInt32(color.G),
                Convert.ToInt32(color.B)
            );
        }

        public Color toColor()
        {
            return Color.FromArgb(R, G, B);
        }
    }
}