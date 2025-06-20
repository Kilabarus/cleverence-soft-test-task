using Problem_3.LogRecordSerializers;
using Problem_3.Model;

namespace Problem_3.LogRecordWriters
{
    internal class FileLogRecordWriter : ILogRecordWriter
    {
        private readonly ILogRecordSerializer _logRecordSerializer;

        private readonly string _filePath;

        public FileLogRecordWriter(ILogRecordSerializer logRecordSerializer, string filePath)
        {
            _logRecordSerializer = logRecordSerializer;
            _filePath = filePath;
        }

        public void WriteLogRecords(IEnumerable<LogRecord> logRecords)
        {
            IEnumerable<string> logRecordsStrings = logRecords.Select(_logRecordSerializer.Serialize);
            File.WriteAllLines(_filePath, logRecordsStrings);
        }
    }
}
