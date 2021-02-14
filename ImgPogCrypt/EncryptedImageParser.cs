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
                result.Add(color.R + color.G + color.B);
            });
            return result;
        }
    }
}