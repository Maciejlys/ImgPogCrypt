using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class EncryptedImageParser
    {
        public List<RgbDifference> Parse(Bitmap bitmap)
        {
            List<RgbDifference> result = new List<RgbDifference>();

            BitmapUtil.Iterate(bitmap, point =>
            {
                Color color = bitmap.GetPixel(point.X, point.Y);
                result.Add(new RgbDifference(color.R, color.G, color.B));
            });
            return result;
        }
    }
}