using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Model
{
    internal class LogRecord
    {
        public DateOnly Date { get; init; }
        public required string TimeRaw { get; init; }
        public required LogLevel LogLevel { get; init; }
        public required string Message { get; init; }
        public string? CalledMethod { get; init; }
    }
}
