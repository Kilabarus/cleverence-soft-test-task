using Problem_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class LogParseResult
    {
        public ICollection<LogRecord> SuccessfullyParsedRecords { get; init; } = [];
        public ICollection<string> FailedToParseRecords { get; init; } = [];
    }
}
