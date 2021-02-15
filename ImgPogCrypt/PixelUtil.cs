using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class PixelUtil
    {
        public static bool IsPixelWritable(Color pixel)
        {
            NumberColor numberColor = NumberColor.fromColor(pixel);
            return (numberColor.R <= 254 || numberColor.G <= 254 || numberColor.B <= 254) && numberColor.A > 0;
        }

        public static bool IsPixelReadable(Color pixel)
        {
            NumberColor numberColor = NumberColor.fromColor(pixel);
            return numberColor.A > 0;
        }
    }
}