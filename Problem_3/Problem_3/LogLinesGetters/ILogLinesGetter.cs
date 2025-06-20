using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.LogLinesGetters
{
    internal interface ILogLinesGetter
    {
        public IEnumerable<string> GetLogLines();
    }
}
