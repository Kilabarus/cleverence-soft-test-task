using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3.RegexBuilders
{
    internal class Format1RegexBuilder : IRegexBuilder
    {
        private const string _dateGroupName = "date";
        private const string _timeGroupName = "time";
        private const string _logLevelGroupName = "logLevel";
        private const string _messageGroupName = "message";

        private const string _date = @$"(?<{_dateGroupName}>\d{{2}}\.\d{{2}}\.\d{{4}})";
        private const string _time = @$"(?<{_timeGroupName}>\d{{2}}:\d{{2}}:\d{{2}}\.\d{{3}})";
        private const string _logLevel = @$"(?<{_logLevelGroupName}>[A-Z]+)";
        private const string _message = @$"(?<{_messageGroupName}>.+)";

        public Regex Build()
        {
            string regexString = @$"^\s*{_date}\s+{_time}\s+{_logLevel}\s+{_message}$";
            return new Regex(regexString, RegexOptions.Compiled);
        }

        public RegexGroupNames GetGroupNames()
        {
            return new RegexGroupNames()
            {
                Date = _dateGroupName,
                Time = _timeGroupName,
                LogLevel = _logLevelGroupName,
                Message = _messageGroupName,
            };
        }
    }
}
