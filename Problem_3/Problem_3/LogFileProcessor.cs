using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class LogFileProcessor
    {
        private readonly IEnumerable<ILogParser> _parsers;

        public LogFileProcessor(IEnumerable<ILogParser> parsers)
        {
            _parsers = parsers;
        }

        public void ProcessLogFile(string inputFilePath, string outputFilePath, string problemsFilePath)
        {
            IEnumerable<string> logLines = File.ReadAllLines(inputFilePath);
            LogParseResult logParseResult = ProcessLogLines(logLines);

            WriteLogRecordsToFile(logParseResult.SuccessfullyParsedRecords, outputFilePath);
            WriteStringsToFile(logParseResult.FailedToParseRecords, problemsFilePath);
        }

        private void WriteLogRecordsToFile(IEnumerable<LogRecord> logRecords, string filePath)
        {
            string fileContent = string.Join(Environment.NewLine, logRecords);
            File.WriteAllText(filePath, fileContent);
        }

        private void WriteStringsToFile(IEnumerable<string> logLines, string filePath)
        {
            string fileContent = string.Join(Environment.NewLine, logLines);
            File.WriteAllText(filePath, fileContent);
        }

        private LogParseResult ProcessLogLines(IEnumerable<string> logLines)
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

        private bool TryParseLogLine(string logLine, out LogRecord? logRecord)
        {
            foreach (var parser in _parsers)
            {
                if (parser.TryParse(logLine, out logRecord))
                {
                    return true;
                }
            }

            logRecord = null;
            return false;
        }
    }
}
