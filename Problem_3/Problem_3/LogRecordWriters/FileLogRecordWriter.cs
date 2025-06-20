using Microsoft.Extensions.Options;
using Problem_3.Configuration;
using Problem_3.LogRecordSerializers;
using Problem_3.Model;

namespace Problem_3.LogRecordWriters
{
    internal class FileLogRecordWriter : ILogRecordWriter
    {
        private readonly ILogRecordSerializer _logRecordSerializer;

        private readonly string _filePath;

        public FileLogRecordWriter(ILogRecordSerializer logRecordSerializer, IOptions<LogProcessingOptions> options)
        {
            _logRecordSerializer = logRecordSerializer;
            _filePath = options.Value.OutputFilePath;
        }

        public void WriteLogRecords(IEnumerable<LogRecord> logRecords)
        {
            IEnumerable<string> logRecordsStrings = logRecords.Select(_logRecordSerializer.Serialize);
            File.WriteAllLines(_filePath, logRecordsStrings);
        }
    }
}
