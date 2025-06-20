namespace Problem_3.LogLinesGetters
{
    internal class FileLogLinesGetter : ILogLinesGetter
    {
        private readonly string _filePath;

        public FileLogLinesGetter(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<string> GetLogLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
