using Problem_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.LogRecordSerializers
{
    internal interface ILogRecordSerializer
    {
        public string Serialize(LogRecord logRecord);
    }
}
