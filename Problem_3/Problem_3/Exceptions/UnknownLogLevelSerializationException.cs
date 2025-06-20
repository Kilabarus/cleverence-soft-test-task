using Problem_3.Model;

namespace Problem_3.Exceptions
{
    internal class UnknownLogLevelSerializationException : Exception
    {
        public LogLevel LogLevel { get; }

        public UnknownLogLevelSerializationException(LogLevel logLevel)
            : base($"Попытка сериализовать неизвестный уровень логирования: {logLevel}")
        {
            LogLevel = logLevel;
        }
    }
}
