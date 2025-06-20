using Problem_3.Model;

namespace Problem_3
{
    internal class LogParseResult
    {
        public ICollection<LogRecord> SuccessfullyParsedRecords { get; init; } = [];
        public ICollection<string> FailedToParseRecords { get; init; } = [];
    }
}
