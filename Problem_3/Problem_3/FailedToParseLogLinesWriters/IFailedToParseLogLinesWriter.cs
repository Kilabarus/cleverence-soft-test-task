namespace Problem_3.FailedToParseLogLinesWriters
{
    internal interface IFailedToParseLogLinesWriter
    {
        public void WriteLogLines(IEnumerable<string> logLines);
    }
}
