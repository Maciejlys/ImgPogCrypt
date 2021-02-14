using System.Collections.Generic;
using ImgPogCrypt;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;
using Xunit;

namespace ImgPogCryptTests
{
    public class BaseDecrytptorTest
    {
        private IDecryptor _decryptor;

        public BaseDecrytptorTest()
        {
            _decryptor = new BaseDecryptor();
        }

        [Fact]
        public void binary_to_string()
        {
            string expected = "z";
            List<RgbDifference> rgbDifferences = new List<RgbDifference>();
            // 01111010
            rgbDifferences.Add(new RgbDifference(0,1,1));
            rgbDifferences.Add(new RgbDifference(1,0,1));
            
            Assert.Equal(expected, _decryptor.Decrypt(rgbDifferences));
        }
    }
}