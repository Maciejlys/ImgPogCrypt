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
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.DoesNotContain(splitBySize.ToList(),
                x => x.Length > 3);
        }

        [Fact]
        public void string_split_first_set_of_bytes()
        {
            string test = "01110100011001010111001101110100";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("011", splitBySize[0]);
        }

        [Fact]
        public void string_split_second_set_of_bytes()
        {
            string test = "01110100011001010111001101110100";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("101", splitBySize[1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_3()
        {
            string test = "101";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("101", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_4()
        {
            string test = "1011";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("100", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_5()
        {
            string test = "10111";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("110", splitBySize[^1]);
        }

        [Fact]
        public void string_split_last_set_of_bytes_length_6()
        {
            string test = "101101";
            string[] splitBySize = StringUtil.SplitStringToSet(test);
            Assert.Equal("101", splitBySize[^1]);
        }

        [Fact]
        public void string_build_check()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Assert.Equal(0, stringBuilder.Length);
        }
    }
}