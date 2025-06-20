using Problem_3.LogParsers;
using Problem_3.RegexBuilders;
using Problem_3.Model;

namespace Problem_3_Tests
{
    public class Format1LogParserTests
    {
        private readonly Format1LogParser _parser;

        public Format1LogParserTests()
        {
            IRegexBuilder regexBuilder = new Format1RegexBuilder();
            _parser = new Format1LogParser(regexBuilder);
        }

        [Fact]
        public void TryParse_ValidLogLine_TrueIsReturnedAndLogRecordAsExpected()
        {
            string logLine = "10.03.2025 15:14:49.523 INFORMATION  Версия программы: '3.4.0.48729'";
            LogRecord expected = new()
            {
                Date = new(2025, 3, 10),
                TimeRaw = "15:14:49.523",
                LogLevel = LogLevel.Information,
                Message = "Версия программы: '3.4.0.48729'",
                CalledMethod = null
            };

            bool isSuccessful = _parser.TryParse(logLine, out LogRecord actual);

            Assert.True(isSuccessful);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        
        [InlineData("           01:01:01.001 INFORMATION Сообщение")]
        [InlineData("01.01.2000              INFORMATION Сообщение")]
        [InlineData("01.01.2000 01:01:01.001             Сообщение")]
        [InlineData("01.01.2000 01:01:01.001 INFORMATION ")]

        [InlineData("99.01.2000 01:01:01.001 INFORMATION Сообщение")]
        [InlineData("2000-01-01 01:01:01.001 INFORMATION Сообщение")]
        [InlineData("01.01.2000 99:01:01.001 INFORMATION Сообщение")]
        [InlineData("01.01.2000 01:01:01.001 UNKNOWN Сообщение")]
        
        [InlineData("01.01.2000 01:01:01.001|INFORMATION|Сообщение")]
        
        public void TryParse_InvalidLogLines_FalseIsReturned(string input)
        {
            bool isSuccessful = _parser.TryParse(input, out _);

            Assert.False(isSuccessful);
        }
    }
}
