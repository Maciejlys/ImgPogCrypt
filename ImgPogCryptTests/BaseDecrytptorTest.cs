using System.Collections.Generic;
using System.Linq;
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
            string diffs = "01111010";
            List<int> diff = new List<int>();
            diffs.ToList().ForEach(x=>diff.Add(int.Parse(x.ToString())));
            string result = _decryptor.Decrypt(diff);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void binary_to_string_big()
        {
            string expected = "check";
            string diffs = "01100011 01101000 01100101 01100011 01101011 ";
            diffs = StringUtil.RemoveSpaces(diffs);
            List<int> diff = new List<int>();
            diffs.ToList().ForEach(x=>diff.Add(int.Parse(x.ToString())));
            string result = _decryptor.Decrypt(diff);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void binary_to_string_big_2()
        {
            string expected = "check";
            string diffs = "01100011 01101000 01100101 01100011 011010111";
            diffs = StringUtil.RemoveSpaces(diffs);
            List<int> diff = new List<int>();
            diffs.ToList().ForEach(x=>diff.Add(int.Parse(x.ToString())));
            string result = _decryptor.Decrypt(diff);
            Assert.Equal(expected, result);
        }
    }
}