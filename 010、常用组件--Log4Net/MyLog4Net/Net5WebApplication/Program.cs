using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Net5WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logBuilder =>
                {
                    logBuilder.ClearProviders();//删除所有其他的关于日志记录的配置
                    logBuilder.SetMinimumLevel(LogLevel.Trace);//设置最低的log级别
                    logBuilder.AddLog4Net("CfgFile/log4Net.config");//支持log4net
                });
    }
}
