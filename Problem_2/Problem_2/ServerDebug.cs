namespace Problem_2
{
    internal static class ServerDebug
    {
        private static int count = 0;

        private static readonly ReaderWriterLockSlim lockSlim = new();

        private static int ReadDelayMs = 1000;
        private static int WriteDelayMs = 3000;

        public static int GetCountDebug()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Чтение: ожидание лока");

            lockSlim.EnterReadLock();            

            try
            {
                Console.WriteLine($"Чтение: начало чтения");
                Thread.Sleep(ReadDelayMs);
                Console.WriteLine($"Чтение: конец чтения, count = {count}");

                return count;
            }
            finally
            {
                Console.WriteLine($"Чтение: освобождение лока");
                lockSlim.ExitReadLock();
            }
        }

        public static void AddToCountDebug(int value)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($" Запись: ожидание лока");
            lockSlim.EnterWriteLock();

            try
            {
                Console.WriteLine($" Запись: начало записи");
                Thread.Sleep(WriteDelayMs);

                count += value;

                Console.WriteLine($" Запись: конец записи, count = {count}");
            }
            finally
            {
                Console.WriteLine($" Запись: освобождение лока");
                lockSlim.ExitWriteLock();
            }
        }
    }
}
