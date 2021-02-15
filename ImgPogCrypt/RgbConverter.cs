using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class RgbConverter
    {
        public Bitmap ToBitmap(List<int> bits)
        {
            int size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(bits.Count)));
            Bitmap map = new Bitmap(size, size);
            BitmapUtil.FillBitmapWithColor(Color.FromArgb(2, 2, 2), map);

            BitmapUtil.Iterate(map, bits,
                (point, diff) => { map.SetPixel(point.X, point.Y, Color.FromArgb(diff, 0, 0)); });
            return map;
        }

        public Bitmap ToBitmap(List<int> bits, Bitmap image)
        {
            if (IsImageTooSmall(bits.Count, image))
                throw new ArgumentException("Image is too small!");

            // Bitmap newImage = new Bitmap(image.Width, image.Height);
            Bitmap newImage = new Bitmap(image);
            BitmapUtil.Iterate(image, bits, (point, diff) =>
            {
                NumberColor numberColor = NumberColor.fromColor(image.GetPixel(point.X, point.Y));
                if (numberColor.R <= 253)
                {
                    numberColor.R += diff;
                }
                else if (numberColor.G <= 253)
                {
                    numberColor.G += diff;
                }
                else if (numberColor.B <= 253)
                {
                    numberColor.B += diff;
                }

                newImage.SetPixel(point.X, point.Y, numberColor.toColor());
            });
            return newImage;
        }

        public bool IsImageTooSmall(int diffsCount, Bitmap image)
        {
            int capablePixelsCount = 0;
            BitmapUtil.Iterate(image, point =>
            {
                if (PixelUtil.IsPixelWritable(image.GetPixel(point.X, point.Y)))
                    capablePixelsCount++;
            });
            Console.WriteLine($"Found {capablePixelsCount} writable pixels, {diffsCount} required");
            return capablePixelsCount < diffsCount;
        }
    }
}