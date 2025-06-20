namespace Problem_3.Exceptions
{
    internal class UndefinedCalledMethodRegexGroupNameException : Exception
    {
        public UndefinedCalledMethodRegexGroupNameException() : base($"Название группы для вызвавшего метода не было определено") { }
    }
}
