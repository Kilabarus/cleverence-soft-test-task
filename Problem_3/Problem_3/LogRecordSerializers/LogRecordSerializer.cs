using Problem_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.LogRecordSerializers
{
    internal class LogRecordSerializer : ILogRecordSerializer
    {
        private const string SEPARATOR = "\t";
        private const string DATE_FORMAT = "dd-MM-yyyy";

        public string Serialize(LogRecord logRecord)
        {
            string dateString = logRecord.Date.ToString(DATE_FORMAT);
            string logLevelString = SerializeLogLevel(logRecord.LogLevel);
            string calledMethod = logRecord.CalledMethod is null 
                ? "DEFAULT"
                : logRecord.CalledMethod;

            return $"{dateString}{SEPARATOR}" +
                $"{logRecord.TimeRaw}{SEPARATOR}" +
                $"{logLevelString}{SEPARATOR}" +
                $"{calledMethod}{SEPARATOR}" +
                $"{logRecord.Message}";
        }

        private static string SerializeLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Information => "INFO",
                LogLevel.Warning => "WARN",
                LogLevel.Error => "ERROR",
                LogLevel.Debug => "DEBUG",
                _ => throw new Exception(),
            };
        }
    }
}
