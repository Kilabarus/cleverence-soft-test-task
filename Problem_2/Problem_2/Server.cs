namespace Problem_2
{
    internal static class Server
    {
        private static int count = 0;

        private static readonly ReaderWriterLockSlim lockSlim = new();

        public static int GetCount()
        {
            lockSlim.EnterReadLock();

            try
            {
                return count;
            }
            finally
            {
                lockSlim.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            lockSlim.EnterWriteLock();

            try
            {
                count += value;
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }
    }
}
