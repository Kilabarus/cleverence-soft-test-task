using Moq;
using Problem_3;
using Problem_3.FailedToParseLogLinesWriters;
using Problem_3.LogLinesGetters;
using Problem_3.LogParsers;
using Problem_3.LogRecordWriters;
using Problem_3.Model;

namespace Problem_3_Tests
{
    public class LogsProcessorTests
    {
        [Fact]
        public void ProcessLogFile_ValidAndInvalidLogLine_ShouldWriteParsedRecordsAndLogFailedOnes()
        {
            Mock<ILogParser> mockParser = new();
            Mock<ILogLinesGetter> mockGetter = new();
            Mock<ILogRecordWriter> mockWriter = new();
            Mock<IFailedToParseLogLinesWriter> mockFailedWriter = new();

            string validLogLine = "valid log line";
            string invalidLogLine = "invalid log line";

            LogRecord validRecord = new();
            LogRecord invalidRecord = new();

            mockParser.Setup(p => p.TryParse(validLogLine, out validRecord)).Returns(true);
            mockParser.Setup(p => p.TryParse(invalidLogLine, out invalidRecord)).Returns(false);

            mockGetter.Setup(g => g.GetLogLines()).Returns([validLogLine, invalidLogLine]);

            var processor = new LogsProcessor(
                [mockParser.Object],
                mockGetter.Object,
                mockWriter.Object,
                mockFailedWriter.Object
            );

            processor.ProcessLogFile();

            mockWriter.Verify(
                w => w.WriteLogRecords(
                    It.Is<List<LogRecord>>(r => r.Count == 1 && r[0] == validRecord)),
                Times.Once);

            mockFailedWriter.Verify(
                w => w.WriteLogLines(
                    It.Is<List<string>>(l => l.Count == 1 && l[0] == invalidLogLine)),
                Times.Once);
        }
    }
}
