using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.LogParsers
{
    internal static class LogLevelParser
    {
        public static bool TryParse(string logLevelString, out LogLevel logLevel)
        {
            switch (logLevelString.ToUpper())
            {
                case "INFORMATION":
                case "INFO":
                    logLevel = LogLevel.Information;
                    return true;
                case "WARNING":
                case "WARN":
                    logLevel = LogLevel.Warning;
                    return true;
                case "ERROR":
                    logLevel = LogLevel.Error;
                    return true;
                case "DEBUG":
                    logLevel = LogLevel.Debug;
                    return true;
                default:
                    logLevel = default;
                    return false;
            }
        }
    }
}
