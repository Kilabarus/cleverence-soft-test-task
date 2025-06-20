using Microsoft.Extensions.DependencyInjection;
using Problem_3.Configuration;

namespace Problem_3
{
    internal class Program
    {
        static void Main()
        {
            var provider = ServiceConfigurator.Configure();

            var processor = provider.GetRequiredService<LogsProcessor>();

            processor.ProcessLogFile();
        }
    }
}
