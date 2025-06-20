using Problem_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.LogRecordWriters
{
    internal interface ILogRecordWriter
    {
        public void WriteLogRecords(IEnumerable<LogRecord> logRecords);
    }
}
