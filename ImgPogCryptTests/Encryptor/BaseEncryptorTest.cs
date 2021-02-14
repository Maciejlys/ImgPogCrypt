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
            foreach (int diff in bytes)
            {
                if (diff == 0 || diff == 1)
                {
                }
                else throw new Exception();
            }
        }

        [Fact]
        public void numbers_are_numbers_2()
        {
            var binaryList = _encryptor.Encrypt("test");
            Assert.True(binaryList.TrueForAll(c => c == 0 || c == 1));
        }

        [Fact]
        public void txt_to_binary_first_set_of_word()
        {
            var binaryList = _encryptor.Encrypt("test");
            Assert.Equal(32, binaryList.Count);
            Assert.Equal(0, binaryList[0]);
            Assert.Equal(1, binaryList[1]);
            Assert.Equal(1, binaryList[2]);
        }

        [Fact]
        public void txt_to_binary_small_2()
        {
            var binaryList = _encryptor.Encrypt("a");
            /*
             * Binary representation of character 'a' is 0110 0001
             * but encoder is adding additional 0 at the end to
             * follow the rule that all sets of numbers must be of
             * a length 3
             */
            Assert.Equal(8, binaryList.Count);
            Assert.Equal(0, binaryList[0]);
            Assert.Equal(1, binaryList[1]);
            Assert.Equal(1, binaryList[2]);
            Assert.Equal(0, binaryList[3]);
        }

        [Fact]
        public void txt_to_binary_big()
        {
            var binaryList = _encryptor.Encrypt("test");
            Assert.Equal(32, binaryList.Count);
            Assert.Equal(0, binaryList[0]);
            Assert.Equal(1, binaryList[1]);
            Assert.Equal(1, binaryList[2]);
        }

        [Fact]
        public void txt_to_binary_big_1()
        {
            var binaryList = _encryptor.Encrypt("checking long sentence");
            Assert.Equal(176, binaryList.Count);
            Assert.Equal(0, binaryList[0]);
            Assert.Equal(1, binaryList[1]);
            Assert.Equal(1, binaryList[2]);
        }
    }
}