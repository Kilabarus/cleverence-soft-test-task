using Problem_3.Model;

namespace Problem_3.LogRecordSerializers
{
    internal interface ILogRecordSerializer
    {
        public string Serialize(LogRecord logRecord);
    }
}
