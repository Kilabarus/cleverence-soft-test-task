using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Configuration
{
    internal class LogProcessingOptions
    {
        public string InputFilePath { get; set; } = null!;
        public string OutputFilePath { get; set; } = null!;
        public string ProblemsFilePath { get; set; } = null!;
    }
}
