using Problem_1;

namespace Problem_1_Tests
{
    public class DecompressorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("a2", "aa")]
        [InlineData("a3", "aaa")]
        [InlineData("a10", "aaaaaaaaaa")]
        [InlineData("a12", "aaaaaaaaaaaa")]

        [InlineData("z", "z")]

        [InlineData("az", "az")]
        [InlineData("a2z", "aaz")]
        [InlineData("az2", "azz")]
        [InlineData("a2z2", "aazz")]

        [InlineData("ab2c3", "abbccc")]
        [InlineData("a3b2c", "aaabbc")]
        [InlineData("a3bc3", "aaabccc")]

        [InlineData("a3b2c3d2e", "aaabbcccdde")]
        public void Decompress_WorksCorrectly(string input, string expected)
        {
            string actual = Decompressor.Decompress(input);

            Assert.Equal(expected, actual);
        }
    }
}
