using Microsoft.Extensions.Options;
using Problem_3.Configuration;

namespace Problem_3.FailedToParseLogLinesWriters
{
    internal class FailedToParseLogLinesWriter : IFailedToParseLogLinesWriter
    {
        private readonly string _filePath;

        public FailedToParseLogLinesWriter(IOptions<LogProcessingOptions> options)
        {
            _filePath = options.Value.ProblemsFilePath;
        }

        public void WriteLogLines(IEnumerable<string> logLines)
        {
            File.WriteAllLines(_filePath, logLines);
        }
    }
}
