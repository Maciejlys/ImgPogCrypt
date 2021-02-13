using System.Drawing;

namespace ImgPogCrypt
{
    public class BitmapUtil
    {
        public delegate void IterationCallback(Point point);
        
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
    }
}