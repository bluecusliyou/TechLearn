using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

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
                    logBuilder.AddNLog("CfgFile/NLog.config");//支持nlog
                });
    }
}
