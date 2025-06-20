namespace Problem_2
{
    internal class Program
    {
        private const int readersCount = 8;
        private const int writersCount = 3;

        private const int minCountToAdd = 1;
        private const int maxCountToAdd = 10;

        private const int readersCreationDelay = 2000;
        private const int writersCreationDelay = 6000;

        static void Main(string[] args)
        {
            Task.Run(LaunchReaders);
            Task.Run(LaunchWriters);

            Console.ReadLine();
        }

        private static void LaunchReaders()
        {
            for (int i = 0; i < readersCount; i++)
            {
                Task.Run(ServerDebug.GetCountDebug);
                
                Thread.Sleep(readersCreationDelay);
            }
        }

        private static void LaunchWriters()
        {
            for (int i = 0; i < writersCount; i++)
            {
                int countToAdd = Random.Shared.Next(minCountToAdd, maxCountToAdd);
                Task.Run(() => ServerDebug.AddToCountDebug(countToAdd));

                Thread.Sleep(writersCreationDelay);
            }
        }
    }
}
