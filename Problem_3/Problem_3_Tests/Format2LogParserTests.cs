using Problem_3.LogParsers;
using Problem_3.Model;
using Problem_3.RegexBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3_Tests
{
    public class Format2LogParserTests
    {
        private readonly Format2LogParser _parser;

        public Format2LogParserTests()
        {
            IRegexBuilder regexBuilder = new Format2RegexBuilder();
            _parser = new Format2LogParser(regexBuilder);
        }

        [Fact]
        public void TryParse_ValidLogLine_TrueIsReturnedAndLogRecordAsExpected()
        {
            string logLine = "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'";
            LogRecord expected = new()
            {
                Date = new(2025, 3, 10),
                TimeRaw = "15:14:51.5882",
                LogLevel = LogLevel.Information,
                Message = "Код устройства: '@MINDEO-M40-D-410244015546'",
                CalledMethod = "MobileComputer.GetDeviceId"
            };

            bool isSuccessful = _parser.TryParse(logLine, out LogRecord actual);

            Assert.True(isSuccessful);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]

        [InlineData("           01:01:01.0001| INFO|11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-01              | INFO|11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-01 01:01:01.0001|     |11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-01 01:01:01.0001| INFO|11|| Сообщение")]
        [InlineData("2000-01-01 01:01:01.0001| INFO|11|ВызвавшийМетод|")]

        [InlineData("01.01.2000 01:01:01.0001| INFO|11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-99 01:01:01.0001| INFO|11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-01 99:01:01.0001| INFO|11|ВызвавшийМетод| Сообщение")]
        [InlineData("2000-01-01 01:01:01.0001| UNKN|11|ВызвавшийМетод| Сообщение")]

        [InlineData("2000-01-01 01:01:01.001 INFORMATION Сообщение")]

        public void TryParse_InvalidLogLines_FalseIsReturned(string input)
        {
            bool isSuccessful = _parser.TryParse(input, out _);

            Assert.False(isSuccessful);
        }
    }
}
