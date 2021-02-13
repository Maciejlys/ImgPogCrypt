using System;
using System.Linq;
using ImgPogCrypt;
using Xunit;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;

namespace ImgPogCryptTests.Encryptor
{
    public class BaseEncryptorTest
    {
        // TODO: Decryptor tests
        private IEncryptor _encryptor;

        public BaseEncryptorTest()
        {
            this._encryptor = new BaseEncryptor();
        }

        [Fact]
        public void numbers_are_numbers()
        {
            var bytes = _encryptor.Encrypt("test");
            foreach (RgbDifference diff in bytes)
            {
                if (diff.R != 0 || diff.R != 1
                                || diff.G != 0 || diff.G != 1
                                || diff.B != 0 || diff.B != 1) ;
                else throw new Exception();
            }
        }

        [Fact]
        public void numbers_are_numbers_2()
        {
            var bytes = _encryptor.Encrypt("test");
            bool flag = bytes.TrueForAll(diff => diff.R == 0 || diff.R == 1
                                                             || diff.G == 0 || diff.G == 1
                                                             || diff.B == 0 || diff.B == 1);
            Assert.True(flag);
        }

        [Fact]
        public void txt_to_binary_first_set_of_word()
        {
            var bytes = _encryptor.Encrypt("test");
            // Assert.Equal("011", bytes[0]);
            RgbDifference diff = bytes[0];
            Assert.Equal(0, diff.R);
            Assert.Equal(1, diff.G);
            Assert.Equal(1, diff.B);
        }

        [Fact]
        public void txt_to_binary_small_2()
        {
            var bytes = _encryptor.Encrypt("a");
            /*
             * Binary representation of character 'a' is 0110 0001
             * but encoder is adding additional 0 at the end to
             * follow the rule that all sets of numbers must be of
             * a length 3
             */
            Assert.Equal(3, bytes.Count);
            CompareRgbDifference(new RgbDifference(0, 1, 1), bytes[0]);
            CompareRgbDifference(new RgbDifference(0, 0, 0), bytes[1]);
            CompareRgbDifference(new RgbDifference(0, 1, 0), bytes[2]);
        }

        [Fact]
        public void txt_to_binary_big()
        {
            var bytes = _encryptor.Encrypt("test");
            Assert.Equal(11, bytes.Count);
            CompareRgbDifference(new RgbDifference(0, 1, 1), bytes[0]);
            CompareRgbDifference(new RgbDifference(1, 0, 1), bytes[5]);
            CompareRgbDifference(new RgbDifference(1, 0, 1), bytes[9]);
        }

        [Fact]
        public void txt_to_binary_big_1()
        {
            var bytes = _encryptor.Encrypt("checking long sentence");
            Assert.Equal(59, bytes.Count);
            CompareRgbDifference(new RgbDifference(0, 1, 1), bytes[0]);
            CompareRgbDifference(new RgbDifference(0, 0, 0), bytes[1]);
            CompareRgbDifference(new RgbDifference(1, 1, 0), bytes[2]);
            CompareRgbDifference(new RgbDifference(0, 1, 0), bytes.Last());
        }

        private void CompareRgbDifference(RgbDifference expected, RgbDifference actual)
        {
            Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
        }
    }
}