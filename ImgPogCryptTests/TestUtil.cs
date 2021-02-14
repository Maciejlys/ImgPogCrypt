using ImgPogCrypt.model;
using Xunit;

namespace ImgPogCryptTests
{
    public class TestUtil
    {
        public static void CompareRgbDifference(RgbDifference expected, RgbDifference actual)
        {
            Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
        }
    }
}