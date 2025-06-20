namespace Problem_3.Model
{
    internal class LogRecord
    {
        public DateOnly Date { get; init; }
        public string TimeRaw { get; init; } = null!;
        public LogLevel LogLevel { get; init; }
        public string Message { get; init; } = null!;
        public string? CalledMethod { get; init; }
    }
}
