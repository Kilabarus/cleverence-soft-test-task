using Problem_3.Model;

namespace Problem_3.LogRecordSerializers
{
    internal class LogRecordSerializer : ILogRecordSerializer
    {
        private const string SEPARATOR = "\t";
        private const string DATE_FORMAT = "dd-MM-yyyy";
        private const string DEFAULT_CALLED_METHOD = "DEFAULT";

        public string Serialize(LogRecord logRecord)
        {
            string dateString = logRecord.Date.ToString(DATE_FORMAT);
            string logLevelString = SerializeLogLevel(logRecord.LogLevel);
            string calledMethod = logRecord.CalledMethod is null
                ? DEFAULT_CALLED_METHOD
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
