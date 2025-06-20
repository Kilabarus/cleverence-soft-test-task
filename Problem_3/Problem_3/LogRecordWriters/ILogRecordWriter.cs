using Problem_3.Model;

namespace Problem_3.LogRecordWriters
{
    internal interface ILogRecordWriter
    {
        public void WriteLogRecords(IEnumerable<LogRecord> logRecords);
    }
}
