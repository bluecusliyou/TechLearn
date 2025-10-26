using Microsoft.Extensions.Configuration;
using Serilog;

class Program
{
    static async Task Main(string[] args)
    {
        {
            ////完整示例
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            //try
            //{
            //    Log.Information("Application Starting Up");
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Application start-up failed");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        {
            ////配置文件示例
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //// 创建 Logger
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            //try
            //{
            //    Log.Information("程序启动");
            //    Log.Debug("这是一个调试信息");
            //    Log.Warning("示例警告信息");

            //    // 模拟业务逻辑
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Log.Information("处理第 {Iteration} 次循环", i);
            //    }

            //    throw new Exception("示例异常");
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex, "发生未处理异常");
            //}
            //finally
            //{
            //    Log.Information("程序退出");
            //    Log.CloseAndFlush(); // 确保所有日志都被写入
            //}
        }

        {
            //异步日志示例
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 创建异步日志记录器
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("程序启动（异步模式）");

                // 模拟高并发日志写入
                Parallel.For(0, 100, i =>
                {
                    Log.Information("异步写入日志项 {Number}", i);
                });

                throw new InvalidOperationException("测试异步异常记录");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "异步异常示例");
            }
            finally
            {
                Log.Information("程序结束");
                await Log.CloseAndFlushAsync();  // 异步关闭
            }
        }
    }
}