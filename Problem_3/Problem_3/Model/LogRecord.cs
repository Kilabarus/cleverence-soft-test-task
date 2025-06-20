namespace Problem_3.Model
{
    internal class LogRecord
    {
        public DateOnly Date { get; init; }
        public string TimeRaw { get; init; } = null!;
        public LogLevel LogLevel { get; init; }
        public string Message { get; init; } = null!;
        public string? CalledMethod { get; init; }

        public override bool Equals(object? obj)
        {
            return obj is LogRecord record
                && record.Date == Date
                && record.TimeRaw == TimeRaw
                && record.LogLevel == LogLevel
                && record.Message == Message
                && record.CalledMethod == CalledMethod;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, TimeRaw, LogLevel, Message, CalledMethod);
        }
    }
}
