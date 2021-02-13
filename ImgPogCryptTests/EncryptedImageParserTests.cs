using System.Collections.Generic;
using System.Drawing;
using ImgPogCrypt;
using ImgPogCrypt.model;
using Xunit;

namespace ImgPogCryptTests
{
    public class EncryptedImageParserTests
    {
        [Fact]
        public void decrypting_image_1_x_3()
        {
            Bitmap bitmap = new Bitmap(@"C:\Users\archp\Desktop\TestPng.png");
            EncryptedImageParser encrypter = new EncryptedImageParser();
            List<RgbDifference> rgbDifferences = encrypter.Parse(bitmap);
            RgbDifference expectedFirstPixel = new RgbDifference(0, 0, 0);
            RgbDifference expectedSecondPixel = new RgbDifference(0, 0, 1);
            RgbDifference expectedThirdPixel = new RgbDifference(1, 0, 1);
            
            TestUtil.CompareRgbDifference(expectedFirstPixel, rgbDifferences[0]);
            TestUtil.CompareRgbDifference(expectedSecondPixel, rgbDifferences[1]);
            TestUtil.CompareRgbDifference(expectedThirdPixel, rgbDifferences[2]);
        }
        
        [Fact]
        public void decrypting_image_2_x_2()
        {
            Bitmap bitmap = new Bitmap(@"C:\Users\archp\Desktop\TestPng2.png");
            EncryptedImageParser encrypter = new EncryptedImageParser();
            List<RgbDifference> rgbDifferences = encrypter.Parse(bitmap);
            RgbDifference expectedFp = new RgbDifference(0, 0, 0);
            RgbDifference expectedSp = new RgbDifference(0, 1, 1);
            RgbDifference expectedSlFp = new RgbDifference(0, 1, 0);
            RgbDifference expectedSlSp = new RgbDifference(1, 1, 1);
            
            TestUtil.CompareRgbDifference(expectedFp, rgbDifferences[0]);
            TestUtil.CompareRgbDifference(expectedSp, rgbDifferences[1]);
            TestUtil.CompareRgbDifference(expectedSlFp, rgbDifferences[2]);
            TestUtil.CompareRgbDifference(expectedSlSp, rgbDifferences[3]);
        }
    }
}