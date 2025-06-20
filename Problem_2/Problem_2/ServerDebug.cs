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
            Console.WriteLine($"Поток №{threadId} (ЧТЕНИЕ): ожидание лока для чтения");

            lockSlim.EnterReadLock();

            try
            {
                Console.WriteLine($"Поток №{threadId} (ЧТЕНИЕ): начало чтения");
                Thread.Sleep(ReadDelayMs);
                Console.WriteLine($"Поток №{threadId} (ЧТЕНИЕ): конец чтения");

                return count;
            }
            finally
            {
                Console.WriteLine($"Поток №{threadId} (ЧТЕНИЕ): освобождение лока для чтения");
                lockSlim.ExitReadLock();
            }
        }

        public static void AddToCountDebug(int value)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Поток №{threadId} (ЗАПИСЬ): ожидание лока для записи");
            lockSlim.EnterWriteLock();

            try
            {
                Console.WriteLine($"Поток №{threadId} (ЗАПИСЬ): начало записи");
                Thread.Sleep(WriteDelayMs);
                Console.WriteLine($"Поток №{threadId} (ЗАПИСЬ): конец записи");

                count += value;
            }
            finally
            {
                Console.WriteLine($"Поток №{threadId} (ЗАПИСЬ): освобождение лока для записи");
                lockSlim.ExitWriteLock();
            }
        }
    }
}
