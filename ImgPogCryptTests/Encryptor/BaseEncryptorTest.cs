using System;
using System.Collections.Generic;
using System.Linq;
using ImgPogCrypt;
using Xunit;
using ImgPogCrypt.lib;
using Xunit.Abstractions;

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
        public void proper_type_of_data()
        {
            Type type = _encryptor.StringToByteArray("test").GetType();
            Assert.IsType<string[]>(type.ToString());
        }

        [Fact]
        public void proper_size_of_packet()
        {
            string[] bytes = _encryptor.StringToByteArray("test");
            Assert.DoesNotContain(bytes.ToList(), x => x.Length > 3);
        }

        [Fact]
        public void numbers_are_numbers()
        {
            string[] bytes = _encryptor.StringToByteArray("test");
            foreach (string variable in bytes)
            {
                foreach (char c in variable)
                {
                    if (c == '0' || c == '1') ;
                    else throw new Exception();
                }
            }
        }

        [Fact]
        public void numbers_are_numbers_2()
        {
            string[] bytes = _encryptor.StringToByteArray("test");
            bool flag = StringUtil.JoinSets(bytes).ToList().TrueForAll(c => c == '1' || c == '0');
            Assert.True(flag);
        }

        [Fact]
        public void txt_to_binary_first_set_of_word()
        {
            string[] bytes = _encryptor.StringToByteArray("test");
            Assert.Equal("011", bytes[0]);
        }

        [Fact]
        public void txt_to_binary_small_2()
        {
            string[] bytes = _encryptor.StringToByteArray("a");
            /*
             * Binary representation of character 'a' is 01100001
             * but encoder is adding additional 0 at the end to
             * follow the rule that all sets of numbers must be of
             * a length 3
             */
            Assert.Equal(StringUtil.SplitStringToSet("011000010")
                , bytes);
        }

        [Fact]
        public void txt_to_binary_big()
        {
            string[] bytes = _encryptor.StringToByteArray("test");
            string expectedString = "01110100011001010111001101110100";
            string[] expectedBytes = StringUtil.SplitStringToSet(expectedString);
            Assert.Equal(expectedBytes, bytes);
        }
        
        [Fact]
        public void txt_to_binary_big_1()
        {
            string[] bytes = _encryptor.StringToByteArray("checking long sentence");
            string expected = "01100011 01101000 01100101 01100011 01101011 01101001 01101110 01100111 00100000 01101100 01101111 01101110 01100111 00100000 01110011 01100101 01101110 01110100 01100101 01101110 01100011 01100101 00001010";
            string trimmed = String.Concat(expected.Where(c => !Char.IsWhiteSpace(c)));
            while (trimmed.Length % 3 != 0)
            {
                trimmed += '0';
            }
            Assert.Equal(trimmed, StringUtil.JoinSets(bytes));
        }
    }
}