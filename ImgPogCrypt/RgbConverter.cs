using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class RgbConverter
    {
        public Bitmap ToBitmap(List<int> diffs)
        {
            int size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(diffs.Count)));
            Bitmap map = new Bitmap(size, size);
            BitmapUtil.FillBitmapWithColor(Color.White, map);

            BitmapUtil.Iterate(map, diffs,
                (point, diff) =>
                {
                    map.SetPixel(point.X, point.Y, Color.FromArgb(diff, 0, 0));
                });
            return map;
        }

        public Bitmap ToBitmap(List<int> diffs, Bitmap image)
        {
            if (IsImageTooSmall(diffs.Count, image))
                throw new ArgumentException("Image is too small!");

            Bitmap newImage = new Bitmap(image);
            BitmapUtil.Iterate(image, diffs, (point, diff) =>
            {
                Color pixel = image.GetPixel(point.X, point.Y);
                if (!PixelColorLimitExceeded(pixel))
                {
                    NumberColor nColor = NumberColor.fromColor(pixel);
                    if (nColor.R < 253)
                    {
                        nColor.R += diff;
                    } else if (nColor.G < 253)
                    {
                        nColor.G += diff;
                    } else if (nColor.B < 253)
                    {
                        nColor.B += diff;
                    }
                    newImage.SetPixel(point.X, point.Y, nColor.toColor());
                }
            });
            return newImage;
        }

        public bool PixelColorLimitExceeded(Color pixel) => (pixel.R > 253 || pixel.G > 253 || pixel.B > 253);

        public bool IsImageTooSmall(int diffsCount, Bitmap image)
        {
            int capablePixelsCount = 0;
            BitmapUtil.Iterate(image, point =>
            {
                Color pixel = image.GetPixel(point.X, point.Y);
                if (pixel.R < 253 || pixel.G < 253 || pixel.B < 253)
                    capablePixelsCount++;
            });
            return capablePixelsCount < diffsCount;
        }
    }
}