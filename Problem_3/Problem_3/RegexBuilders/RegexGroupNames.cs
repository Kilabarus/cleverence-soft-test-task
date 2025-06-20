using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.RegexBuilders
{
    internal class RegexGroupNames
    {
        public required string Date { get; init; }
        public required string Time { get; init; }
        public required string LogLevel { get; init; }
        public required string Message { get; init; }
        public string? CalledMethod { get; init; }
    }
}
