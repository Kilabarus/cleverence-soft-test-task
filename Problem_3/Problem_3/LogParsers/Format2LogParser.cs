using Problem_3.RegexBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3.LogParsers
{
    internal class Format2LogParser : ILogParser
    {
        private readonly Regex _regex;
        private readonly RegexGroupNames _groupNames;

        public Format2LogParser(IRegexBuilder regexBuilder)
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

            string date = match.Groups[_groupNames.Date].Value;
            string time = match.Groups[_groupNames.Time].Value;
            string levelRaw = match.Groups[_groupNames.LogLevel].Value;
            string message = match.Groups[_groupNames.Message].Value;

            if (_groupNames.CalledMethod is null)
            {
                throw new Exception();
            }
            string calledMethod = match.Groups[_groupNames.CalledMethod].Value;
            
            string timeStampRaw = $"{date} {time}";
            if (!DateTime.TryParse(timeStampRaw, out DateTime timeStamp))
            {
                return false;
            }

            if (!LogLevelParser.TryParse(levelRaw, out LogLevel logLevel))
            {
                return false;
            }

            logRecord = new LogRecord
            {
                TimeStamp = timeStamp,
                LogLevel = logLevel,
                CalledMethod = calledMethod,
                Message = message
            };

            return true;
        }
    }
}
