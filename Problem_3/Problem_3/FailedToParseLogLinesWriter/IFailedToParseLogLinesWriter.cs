using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.FailedToParseLogLinesWriter
{
    internal interface IFailedToParseLogLinesWriter
    {
        public void WriteLogLines(IEnumerable<string> logLines);
    }
}
