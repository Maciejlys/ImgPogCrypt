using System;
using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;
using Xunit;

namespace ImgPogCryptTests
{
    public class RgbConverterTest
    {
        private readonly RgbConverter _converter;
        private readonly IEncryptor _encryptor;

        public RgbConverterTest()
        {
            this._encryptor = new BaseEncryptor();
            this._converter = new RgbConverter();
        }

        [Fact]
        public void convert_simple_data()
        {
            // 32 rgb diffs
            // 6x6 map
            EncryptAndValidate("test message");
        }

        [Fact]
        public void convert_numbers()
        {
            EncryptAndValidate("123123123123");
        }

        [Fact]
        public void convert_long_string()
        {
            EncryptAndValidate("Lorem ipsum dolor sit amet, " +
                               "consectetur adipiscing elit. Aenean aliquet " +
                               "ullamcorper orci vitae laoreet. Nullam fermentum " +
                               "viverra est nec iaculis. Morbi cursus massa eu risus" +
                               " semper congue. Vestibulum volutpat at dui a sollicitud" +
                               "in. Phasellus euismod tincidunt massa, ut faucibus elit b" +
                               "landit at. Mauris felis lorem, maximus mollis semper a, " +
                               "aliquet eget nulla. Morbi semper feugiat venenatis. Done" +
                               "c at pretium odio.");
        }

        [Fact]
        public void convert_empty_and_expect_error()
        {
            Assert.Throws<ArgumentException>(() => EncryptAndValidate(""));
        }

        [Fact]
        public void check_image_memory()
        {
            // 10x10 = 100 memory pixels
            Bitmap example = new Bitmap(10, 10);
            Assert.False(_converter.IsImageTooSmall(5, example));
        }

        [Fact]
        public void check_image_memory_expect_error()
        {
            Bitmap example = new Bitmap(1, 1);
            example.SetPixel(0, 0, Color.White);
            Assert.True(_converter.IsImageTooSmall(1, example));
        }

        [Fact]
        public void check_image_memory_2()
        {
            Bitmap example = new Bitmap(2, 1);
            example.SetPixel(0, 0, Color.White);
            Assert.False(_converter.IsImageTooSmall(1, example));
        }

        [Fact]
        public void check_image_copy()
        {
            Bitmap inputImage = new Bitmap(1, 1);
            RgbDifference exampleRgb = new RgbDifference(1, 0, 1);
            List<RgbDifference> diffs = new List<RgbDifference>() { exampleRgb };
            Bitmap result = _converter.ToBitmap(diffs, inputImage);
            CompareRgbDifference(exampleRgb, RgbDifference.fromColor(result.GetPixel(0, 0)));
        }

        [Fact]
        public void check_image_copy_2()
        {
            Bitmap inputImage = new Bitmap(1, 1);
            inputImage.SetPixel(0, 0, Color.FromArgb(200, 200, 200));
            RgbDifference exampleRgb = new RgbDifference(1, 0, 1);
            List<RgbDifference> diffs = new List<RgbDifference>() { exampleRgb };
            Bitmap result = _converter.ToBitmap(diffs, inputImage);
            Assert.Equal(Color.FromArgb(201, 200, 201), result.GetPixel(0, 0));
        }
        
        private void EncryptAndValidate(string message)
        {
            List<RgbDifference> diffs = _encryptor.Encrypt(message);
            Bitmap result = _converter.ToBitmap(diffs);
            Assert.True((result.Width * result.Height) >= diffs.Count);

            BitmapUtil.Iterate(result, diffs, (point, diff) =>
            {
                Color color = result.GetPixel(point.X, point.Y);
                CompareRgbDifference(diff, RgbDifference.fromColor(color));
            });
        }

        private void CompareRgbDifference(RgbDifference expected, RgbDifference actual)
        {
            Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
        }
    }
}