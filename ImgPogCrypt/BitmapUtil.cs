﻿using System.Collections.Generic;
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
            Point position = new Point(0, 0);
            foreach (int diff in diffs)
            {
                if (position.X >= image.Width)
                {
                    position.X = 0;
                    position.Y++;
                }

                callback(position, diff);
                position.X++;
            }
        }
    }
}