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
        private const string _date = @"(?<date>\d{2}\.\d{2}\.\d{4})";
        private const string _time = @"(?<time>\d{2}:\d{2}:\d{2}\.\d{3})";
        private const string _logLevel = @"(?<logLevel>[A-Z]+)";
        private const string _message = @"(?<message>.+)";

        public Regex Build()
        {
            string regexString = @$"^\s*{_date}\s+{_time}\s+{_logLevel}\s+{_message}$";
            return new Regex(regexString, RegexOptions.Compiled);
        }
    }
}
