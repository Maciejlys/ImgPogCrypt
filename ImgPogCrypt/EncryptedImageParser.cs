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

        public List<int> Parse(Bitmap bitmap, Bitmap basemap)
        {
            List<int> result = new List<int>();
            if (bitmap.Width != basemap.Width || bitmap.Height != basemap.Height)
                throw new ArgumentException("Invalid base image!");

            BitmapUtil.Iterate(bitmap, point =>
            {
                NumberColor bitmapColor = NumberColor.fromColor(bitmap.GetPixel(point.X, point.Y));
                NumberColor basemapColor = NumberColor.fromColor(basemap.GetPixel(point.X, point.Y));
                if (PixelUtil.IsPixelReadable(bitmap.GetPixel(point.X, point.Y)) && PixelUtil.IsPixelReadable(basemap.GetPixel(point.X, point.Y)))
                {
                    int colorDiff = bitmapColor.SubtractNumberColor(basemapColor);
                    result.Add(colorDiff);
                }
            });
            return result;
        }
    }
}