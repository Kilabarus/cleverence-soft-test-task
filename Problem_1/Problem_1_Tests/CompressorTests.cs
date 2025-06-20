using Problem_1;

namespace Problem_1_Tests
{
    public class CompressorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("aa", "a2")]
        [InlineData("aaa", "a3")]
        [InlineData("aaaaaaaaaa", "a10")]

        [InlineData("z", "z")]

        [InlineData("az", "az")]
        [InlineData("aaz", "a2z")]
        [InlineData("azz", "az2")]
        [InlineData("aazz", "a2z2")]

        [InlineData("abbccc", "ab2c3")]
        [InlineData("aaabbc", "a3b2c")]
        [InlineData("aaabccc", "a3bc3")]

        [InlineData("aaabbcccdde", "a3b2c3d2e")]
        public void Compress_WorksCorrectly(string input, string expected)
        {
            string actual = Compressor.Compress(input);

            Assert.Equal(expected, actual);
        }
    }
}
