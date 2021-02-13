using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class RgbConverter
    {
        public Bitmap ToBitmap(List<RgbDifference> diffs)
        {
            int size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(diffs.Count)));
            Bitmap map = new Bitmap(size, size);
            
            BitmapUtil.Iterate(map, diffs, (point, diff) =>
            {
                    map.SetPixel(point.X, point.Y, diff.toColor());
            });
            return map;
        }

        public Bitmap ToBitmap(List<RgbDifference> diffs, Bitmap image)
        {
            if(IsImageTooSmall(diffs.Count, image))
                throw new ArgumentException("Image is too small!");

            Bitmap newImage = new Bitmap(image);
            BitmapUtil.Iterate(image, diffs, (point, diff) =>
            {
                Color pixel = image.GetPixel(point.X, point.Y);
                if (!PixelColorLimitExceeded(pixel))
                {
                    Color newPixel = diff.addColor(pixel);
                    newImage.SetPixel(point.X, point.Y, newPixel);
                }
            });
            return newImage;
        }

        public bool PixelColorLimitExceeded(Color pixel) => (pixel.R > 253 && pixel.G > 253 && pixel.B > 253);
        
        public bool IsImageTooSmall(int diffsCount, Bitmap image)
        {
            int capablePixelsCount = 0;
            BitmapUtil.Iterate(image, point =>
            {
                Color pixel = image.GetPixel(point.X, point.Y);
                if (pixel.R < 253 && pixel.G < 253 && pixel.B < 253)
                    capablePixelsCount++;
            });
            return capablePixelsCount < diffsCount;
        }
    }
}