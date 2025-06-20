using Microsoft.Extensions.Options;
using Problem_3.Configuration;

namespace Problem_3.LogLinesGetters
{
    internal class FileLogLinesGetter : ILogLinesGetter
    {
        private readonly string _filePath;

        public FileLogLinesGetter(IOptions<LogProcessingOptions> options)
        {
            _filePath = options.Value.InputFilePath;
        }

        public IEnumerable<string> GetLogLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
