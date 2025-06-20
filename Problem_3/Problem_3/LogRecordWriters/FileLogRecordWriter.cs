using Problem_3.LogRecordSerializers;
using Problem_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string output = string.Join(Environment.NewLine, logRecordsStrings);

            File.WriteAllText(_filePath, output);
        }
    }
}
