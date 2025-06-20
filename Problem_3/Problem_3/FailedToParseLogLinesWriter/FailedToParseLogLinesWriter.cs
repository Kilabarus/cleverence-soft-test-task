namespace Problem_3.FailedToParseLogLinesWriter
{
    internal class FailedToParseLogLinesWriter : IFailedToParseLogLinesWriter
    {
        private readonly string _filePath;

        public FailedToParseLogLinesWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteLogLines(IEnumerable<string> logLines)
        {
            File.WriteAllLines(_filePath, logLines);
        }
    }
}
