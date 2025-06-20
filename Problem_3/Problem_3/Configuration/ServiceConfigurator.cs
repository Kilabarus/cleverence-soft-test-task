using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Problem_3.FailedToParseLogLinesWriters;
using Problem_3.LogLinesGetters;
using Problem_3.LogParsers;
using Problem_3.LogRecordSerializers;
using Problem_3.LogRecordWriters;
using Problem_3.RegexBuilders;

namespace Problem_3.Configuration
{
    internal static class ServiceConfigurator
    {
        public static IServiceProvider Configure()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var services = new ServiceCollection();

            services.Configure<LogProcessingOptions>(
                configuration.GetSection("FilePaths"));

            services.AddTransient<Format1RegexBuilder>();
            services.AddTransient<Format2RegexBuilder>();

            services.AddTransient<ILogParser>(provider =>
            {
                var builder = provider.GetRequiredService<Format1RegexBuilder>();
                return new Format1LogParser(builder);
            });

            services.AddTransient<ILogParser>(provider =>
            {
                var builder = provider.GetRequiredService<Format2RegexBuilder>();
                return new Format2LogParser(builder);
            });

            services.AddTransient<ILogLinesGetter, FileLogLinesGetter>();
            services.AddTransient<ILogRecordWriter, FileLogRecordWriter>();
            services.AddTransient<IFailedToParseLogLinesWriter, FailedToParseLogLinesWriter>();
            services.AddTransient<ILogRecordSerializer, LogRecordSerializer>();

            services.AddTransient<LogsProcessor>();

            return services.BuildServiceProvider();
        }
    }
}
