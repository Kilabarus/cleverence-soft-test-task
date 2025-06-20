using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class LogRecord
    {
        public DateTime TimeStamp { get; init; }
        public required LogLevel LogLevel { get; init; }
        public required string Message { get; init; }
        public string? CalledMethod { get; init; }
    }
}
