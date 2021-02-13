using System;

namespace ImgPogCrypt.model
{
    public class RgbDifference
    {
        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;

        public RgbDifference(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public RgbDifference(bool r, bool g, bool b)
        {
            R = r ? 1 : 0;
            G = g ? 1 : 0;
            B = b ? 1 : 0;
        }

        public RgbDifference(string rgb)
        {
            R = Int32.Parse(rgb[0].ToString());
            G = Int32.Parse(rgb[1].ToString());
            B = Int32.Parse(rgb[2].ToString());
        }

        public RgbDifference(string r, string g, string b)
        {
            R = Int32.Parse(r);
            G = Int32.Parse(g);
            B = Int32.Parse(b);
        }

        /**
           * 111 -> 111
           * 011 ->  11
           * 001 ->   1
           * 100 -> 100
           * 110 -> 110
           * 000 -> 000
           * 010 ->  10
           * 101 -> 101
       */
        public override int GetHashCode()
        {
            int hashCode = 0;
            if (R == 1) hashCode += 1;
            if (G == 1) hashCode += 10;
            if (B == 1) hashCode += 100;
            return hashCode;
        }
    }
}