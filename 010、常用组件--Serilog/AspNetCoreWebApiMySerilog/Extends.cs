using Serilog;
using Serilog.Events;

namespace AspNetCoreWebApiMySerilog
{
    public static class Extends
    {
        const string infoPath = "Logs/info.log";
        const string warnPath = "Logs/warn.log";
        const string errorPath = "Logs/error.log";
        const string fatalPath = "Logs/fatal.log";
        const string template = "时间: {Timestamp:yyyy-MM-dd HH:mm:ss}{NewLine}来源: {SourceContext}{NewLine}内容: [{Level:u3}] {Message}{NewLine}{Exception}{NewLine}";

        // 可以将日志输出到控制台、文件、数据库、ES等
        public static void AddSerilog(this IServiceCollection c)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // 排除Dotnet自带的日志
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(lev => lev.Level == LogEventLevel.Information).WriteTo.Async(congfig => congfig.File(
                        infoPath,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 1024 * 1024 * 10,    //默认1GB
                        retainedFileCountLimit: 10,                   //保留最近多少个文件,默认31个
                        rollOnFileSizeLimit: true,                       //超过文件大小时,自动创建新文件  
                        shared: true,
                        outputTemplate: template)
                    ))

                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(lev => lev.Level == LogEventLevel.Warning).WriteTo.Async(congfig => congfig.File(
                        warnPath,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 1024 * 1024 * 10,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        shared: true,
                        outputTemplate: template)
                ))

                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(lev => lev.Level == LogEventLevel.Error).WriteTo.Async(congfig => congfig.File(
                        errorPath,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 1024 * 1024 * 10,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        shared: true,
                        outputTemplate: template)
                ))

                .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(lev => lev.Level == LogEventLevel.Fatal).WriteTo.Async(congfig => congfig.File(
                        fatalPath,
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 1024 * 1024 * 10,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        shared: true,
                        outputTemplate: template)
                )).CreateLogger();

            // 注入到容器
            c.AddLogging(opt =>
            {
                opt.ClearProviders();
                opt.AddSerilog(dispose: true);
            });
        }
    }
}