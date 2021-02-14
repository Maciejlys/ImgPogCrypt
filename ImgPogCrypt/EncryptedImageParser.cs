using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class EncryptedImageParser
    {
        public List<int> Parse(Bitmap bitmap)
        {
            List<int> result = new List<int>();

            BitmapUtil.Iterate(bitmap, point =>
            {
                Color color = bitmap.GetPixel(point.X, point.Y);
                int sum = color.R + color.G + color.B;
                if (sum <= 1)
                    result.Add(sum);
            });
            return result;
        }
    }
}