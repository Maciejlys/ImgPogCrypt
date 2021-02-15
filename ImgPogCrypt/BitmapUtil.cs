using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class BitmapUtil
    {
        public delegate void IterationCallback(Point point);

        public delegate void CharIterationCallback(Point point, int diff);

        public static void Iterate(Bitmap image, IterationCallback callback)
        {
            for (int y = 0; y <= image.Height - 1; y++)
            {
                for (int x = 0; x <= image.Width - 1; x++)
                {
                    callback(new Point(x, y));
                }
            }
        }

        public static void Iterate(Bitmap image, List<int> diffs, CharIterationCallback callback)
        {
            int currentDiff = 0;
            Point position = new Point(0, 0);

            while (currentDiff < diffs.Count)
            {
                if (position.X >= image.Width)
                {
                    position.X = 0;
                    position.Y++;
                }

                
                if (PixelUtil.IsPixelWritable(image.GetPixel(position.X, position.Y)))
                {
                    callback(position, diffs[currentDiff]);
                    currentDiff++;
                }
                position.X++;
            }
        }

        public static void FillBitmapWithColor(Color color, Bitmap bitmap)
        {
            Iterate(bitmap, point => { bitmap.SetPixel(point.X, point.Y, color); });
        }
    }
}