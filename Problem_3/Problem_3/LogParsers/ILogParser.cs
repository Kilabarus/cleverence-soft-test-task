using Problem_3.Model;

namespace Problem_3
{
    internal interface ILogParser
    {
        public bool TryParse(string logLine, out LogRecord logRecord);
    }
}
