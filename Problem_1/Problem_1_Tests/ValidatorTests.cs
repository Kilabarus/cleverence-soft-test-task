using Problem_1;

namespace Problem_1_Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("a", true)]
        [InlineData("z", true)]
        [InlineData("abc", true)]

        [InlineData(" ", false)]
        [InlineData("a ", false)]
        [InlineData(" a", false)]
        [InlineData("a a", false)]

        [InlineData("#", false)]
        [InlineData("a#", false)]
        [InlineData("#a", false)]
        [InlineData("a#a", false)]
        public void IsValidStringToCompress_WorksCorrectly(string input, bool expected)
        {
            bool actual = Validator.IsValidStringToCompress(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", true)]
        [InlineData("a", true)]
        [InlineData("z", true)]
        [InlineData("abc", true)]

        [InlineData("a2", true)]
        [InlineData("a2b", true)]
        [InlineData("ab2", true)]
        [InlineData("a2b2", true)]

        [InlineData("aa", false)]
        [InlineData("a2a", false)]
        [InlineData("a2a2", false)]
        [InlineData("a02", false)]

        [InlineData("2a", false)]

        [InlineData(" ", false)]
        [InlineData("a ", false)]
        [InlineData(" a", false)]
        [InlineData("a a", false)]

        [InlineData("#", false)]
        [InlineData("a#", false)]
        [InlineData("#a", false)]
        [InlineData("a#a", false)]

        [InlineData("ab2c3", true)]
        [InlineData("a3b2c", true)]
        [InlineData("a3bc3", true)]

        [InlineData("a3b2c3d2e", true)]
        public void IsValidCompressedString_WorksCorrectly(string input, bool expected)
        {
            bool actual = Validator.IsValidCompressedString(input);

            Assert.Equal(expected, actual);
        }
    }
}