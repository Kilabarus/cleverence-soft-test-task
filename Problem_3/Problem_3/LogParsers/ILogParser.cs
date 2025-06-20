using Problem_3.Model;

namespace Problem_3.LogParsers
{
    internal interface ILogParser
    {
        public bool TryParse(string logLine, out LogRecord logRecord);
    }
}
