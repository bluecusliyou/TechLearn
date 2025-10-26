using Hangfire;
using Hangfire.MySql;
using System;
using System.Transactions;

namespace MyHangfire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //配置存储
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)//全局配置兼容版本，向下兼容
                .UseColouredConsoleLogProvider()//输出日志
                .UseSimpleAssemblyNameTypeSerializer()//使用简单程序集名称类型序列化程序
                .UseRecommendedSerializerSettings()//使用推荐的序列化配置
                .UseStorage(new MySqlStorage(
                 "server=服务器IP地址;Database=hangfiredb;user id=root;password=123456;SslMode=none;",
                 new MySqlStorageOptions
                 {
                     TransactionIsolationLevel = IsolationLevel.ReadCommitted,
                     QueuePollInterval = TimeSpan.FromSeconds(15),
                     JobExpirationCheckInterval = TimeSpan.FromHours(1),
                     CountersAggregateInterval = TimeSpan.FromMinutes(5),
                     PrepareSchemaIfNecessary = true,
                     DashboardJobListLimit = 50000,
                     TransactionTimeout = TimeSpan.FromMinutes(1),
                     TablesPrefix = "Hangfire"
                 }));

            ////客户端创建任务
            //BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

            ////即时任务
            //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("即时任务！"));
            ////延迟任务
            //var jobId2 = BackgroundJob.Schedule(() => Console.WriteLine("延迟任务！"), TimeSpan.FromMilliseconds(10));
            ////重复任务
            //RecurringJob.AddOrUpdate("myrecurringjob", () => Console.WriteLine("重复任务！"), Cron.Minutely);
            ////继续任务
            //BackgroundJob.ContinueJobWith(jobId2,() => Console.WriteLine("jobId2执行完了再继续执行！"));

            //封装任务
            //RecurringJob.AddOrUpdate<SyncUserDataSchedule>(c => c.SyncUserData(), Cron.Minutely);

            //服务器运行任务
            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }
    }
}
