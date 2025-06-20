namespace Problem_3.RegexBuilders
{
    internal readonly struct RegexGroupNames
    {
        public string Date { get; init; }
        public string Time { get; init; }
        public string LogLevel { get; init; }
        public string Message { get; init; }
        public string? CalledMethod { get; init; }
    }
}
