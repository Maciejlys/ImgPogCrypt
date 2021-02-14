using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ImgPogCrypt;
using ImgPogCrypt.model;
using Xunit;

namespace ImgPogCryptTests
{
    public class EncryptedImageParserTests
    {
        private EncryptedImageParser _encrypter = new EncryptedImageParser();


        [Fact]
        public void decrypting_image_1_x_3()
        {
            Bitmap bitmap = new Bitmap(3, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bitmap.SetPixel(1, 0, Color.FromArgb(0, 0, 1));
            bitmap.SetPixel(2, 0, Color.FromArgb(1, 0, 0));
            List<int> rgbDifferences = _encrypter.Parse(bitmap);

            int expectedFirstPixel = 0;
            int expectedSecondPixel = 1;
            int expectedThirdPixel = 1;

            Assert.Equal(expectedFirstPixel, rgbDifferences[0]);
            Assert.Equal(expectedSecondPixel, rgbDifferences[1]);
            Assert.Equal(expectedThirdPixel, rgbDifferences[2]);
        }

        [Fact]
        public void decrypting_image_2_x_2()
        {
            Bitmap bitmap = new Bitmap(2, 2);
            bitmap.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bitmap.SetPixel(1, 0, Color.FromArgb(0, 0, 1));
            bitmap.SetPixel(0, 1, Color.FromArgb(1, 0, 0));
            bitmap.SetPixel(1, 1, Color.FromArgb(0, 0, 1));
            List<int> rgbDifferences = _encrypter.Parse(bitmap);
            int expectedFp = 0;
            int expectedSp = 1;
            int expectedSlFp = 1;
            int expectedSlSp = 1;
            Assert.Equal(expectedFp, rgbDifferences[0]);
            Assert.Equal(expectedSp, rgbDifferences[1]);
            Assert.Equal(expectedSlFp, rgbDifferences[2]);
            Assert.Equal(expectedSlSp, rgbDifferences[3]);
        }

        [Fact]
        public void decrypt_image()
        {
            BaseEncryptor baseEncryptor = new BaseEncryptor();
            RgbConverter rgbConverter = new RgbConverter();
            Bitmap bitmap = rgbConverter.ToBitmap(baseEncryptor.Encrypt("z"));
            List<int> rgbDifferences = _encrypter.Parse(bitmap);
            string exp = "z";
            string expBinary = StringUtil.RemoveSpaces("01111010 ");
            List<int> diffs = new List<int>();
            expBinary.ToList().ForEach(x=>diffs.Add(int.Parse(x.ToString())));
            for (int i = 0; i < diffs.Count; i++)
            {
                Assert.Equal(diffs[i], rgbDifferences[i]);
            }
        }
        
        [Fact]
        public void decrypt_image_test()
        {
            BaseEncryptor baseEncryptor = new BaseEncryptor();
            RgbConverter rgbConverter = new RgbConverter();
            Bitmap bitmap = rgbConverter.ToBitmap(baseEncryptor.Encrypt("test"));
            List<int> rgbDifferences = _encrypter.Parse(bitmap);
            string exp = "z";
            string expBinary = StringUtil.RemoveSpaces("01110100 01100101 01110011 01110100 ");
            List<int> diffs = new List<int>();
            expBinary.ToList().ForEach(x=>diffs.Add(int.Parse(x.ToString())));
            for (int i = 0; i < diffs.Count; i++)
            {
                Assert.Equal(diffs[i], rgbDifferences[i]);
            }
        }
    }
}