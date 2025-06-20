using Problem_3.Model;
using Problem_3.RegexBuilders;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Problem_3.LogParsers
{
    internal class Format1LogParser : ILogParser
    {
        private readonly Regex _regex;
        private readonly RegexGroupNames _groupNames;

        public Format1LogParser(IRegexBuilder regexBuilder)
        {
            _regex = regexBuilder.Build();
            _groupNames = regexBuilder.GetGroupNames();
        }

        public bool TryParse(string logLine, out LogRecord? logRecord)
        {
            logRecord = null;

            Match match = _regex.Match(logLine);
            if (!match.Success)
            {
                return false;
            }

            string dateRaw = match.Groups[_groupNames.Date].Value;
            string timeRaw = match.Groups[_groupNames.Time].Value;
            string levelRaw = match.Groups[_groupNames.LogLevel].Value;
            string message = match.Groups[_groupNames.Message].Value;

            bool dateIsValid = DateOnly.TryParseExact(
                dateRaw,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateOnly date);

            bool timeIsValid = TimeOnly.TryParse(timeRaw, out TimeOnly time);
            bool logLevelIsValid = LogLevelParser.TryParse(levelRaw, out LogLevel logLevel);

            if (!(dateIsValid && timeIsValid && logLevelIsValid))
            {
                return false;
            }

            logRecord = new LogRecord
            {
                Date = date,
                TimeRaw = timeRaw,
                LogLevel = logLevel,
                Message = message,
            };

            return true;
        }
    }
}
