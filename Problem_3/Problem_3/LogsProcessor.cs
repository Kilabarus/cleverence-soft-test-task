using Problem_3.FailedToParseLogLinesWriter;
using Problem_3.LogLinesGetters;
using Problem_3.LogRecordWriters;
using Problem_3.Model;

namespace Problem_3
{
    internal class LogsProcessor
    {
        private readonly IEnumerable<ILogParser> _parsers;

        private readonly ILogLinesGetter _logLinesGetter;
        private readonly ILogRecordWriter _logRecordWriter;
        private readonly IFailedToParseLogLinesWriter _failedToParseLogLinesWriter;

        public LogsProcessor(
            IEnumerable<ILogParser> parsers,
            ILogLinesGetter logLinesGetter,
            ILogRecordWriter logRecordWriter,
            IFailedToParseLogLinesWriter failedToParseLogLinesWriter)
        {
            _parsers = parsers;

            _logLinesGetter = logLinesGetter;
            _logRecordWriter = logRecordWriter;
            _failedToParseLogLinesWriter = failedToParseLogLinesWriter;
        }

        public void ProcessLogFile()
        {
            IEnumerable<string> logLines = _logLinesGetter.GetLogLines();
            LogParseResult logParseResult = TryParseUsingAvailableParsers(logLines);

            _logRecordWriter.WriteLogRecords(logParseResult.SuccessfullyParsedRecords);

            if (logParseResult.FailedToParseRecords.Count > 0)
            {
                _failedToParseLogLinesWriter.WriteLogLines(logParseResult.FailedToParseRecords);
            }
        }

        private LogParseResult TryParseUsingAvailableParsers(IEnumerable<string> logLines)
        {
            LogParseResult result = new();

            foreach (var logLine in logLines)
            {
                if (TryParseLogLine(logLine, out LogRecord? logRecord))
                {
                    if (logRecord is null)
                    {
                        throw new Exception();
                    }

                    result.SuccessfullyParsedRecords.Add(logRecord);
                    continue;
                }

                result.FailedToParseRecords.Add(logLine);
            }

            return result;
        }

        private bool TryParseLogLine(string logLine, out LogRecord logRecord)
        {
            foreach (var parser in _parsers)
            {
                if (parser.TryParse(logLine, out logRecord))
                {
                    return true;
                }
            }

            logRecord = new();
            return false;
        }
    }
}
