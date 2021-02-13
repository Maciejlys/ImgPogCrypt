using System;
using System.Linq;
using System.Text;
using ImgPogCrypt;
using Xunit;

namespace ImgPogCryptTests
{
    public class StringUtilTests
    {
        [Fact]
        public void string_split_size()
        {
            string test = "01110100011001010111001101110100";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.DoesNotContain(splitBySize.ToList(),
                x => x.Length > 3);
        }

        [Fact]
        public void string_split_first_set_of_bytes()
        {
            string test = "01110100011001010111001101110100";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("011", splitBySize[0]);
        }

        [Fact]
        public void string_split_second_set_of_bytes()
        {
            string test = "01110100011001010111001101110100";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("101", splitBySize[1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_3()
        {
            string test = "101";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("101", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_4()
        {
            string test = "1011";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("100", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_5()
        {
            string test = "10111";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("110", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_6()
        {
            string test = "101101";
            string[] splitBySize = StringUtil.SplitStringBySize(test);
            Assert.Equal("101", splitBySize[^1]);
        }

        [Fact]
        public void string_build_check()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Assert.Equal(0, stringBuilder.Length);
        }

        [Fact]
        public void string_split_set_of_2()
        {
            string txt = "1001";
            string[] expected = new[] {"10", "01"};
            Assert.Equal(expected, StringUtil.SplitStringBySize(txt, 2));
        }

        [Fact]
        public void string_split_set_of_4()
        {
            string txt = "10010";
            string[] expected = new[] {"1001", "0000"};
            Assert.Equal(expected, StringUtil.SplitStringBySize(txt, 4));
        }
        
        [Fact]
        public void string_split_set_of_5()
        {
            string txt = "10010 01010";
            string[] expected = new[] {"10010", "01010"};
            Assert.Equal(expected, StringUtil.SplitStringBySize(TrimSpaces(txt), 5));
        }

        [Fact]
        public void string_split_set_of_negative_size()
        {
            string txt = "10010";
            string[] expected = new[] {"1001", "0000"};
            Assert.Throws<ArgumentException>(() => StringUtil.SplitStringBySize(txt, -1));
        }

        private string TrimSpaces(string s)
        {
            return String.Concat(s.Where(c => !Char.IsWhiteSpace(c)));
        }
    }
}