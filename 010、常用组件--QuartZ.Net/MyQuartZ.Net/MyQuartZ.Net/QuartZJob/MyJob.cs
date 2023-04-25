using Quartz;

namespace MyQuartZ.Net.QuartZJob
{
    public class MyJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"【任务执行】：{DateTime.Now}");
            Console.WriteLine($"【触发时间】：{context.ScheduledFireTimeUtc?.LocalDateTime}");
            Console.WriteLine($"【下次触发时间】：{context.NextFireTimeUtc?.LocalDateTime}"); 
            await Task.CompletedTask;
        }
    }
}
