using Quartz;

namespace MyQuartZ.Net.QuartZJob
{
    [DisallowConcurrentExecution, PersistJobDataAfterExecution]
    public class ConcurrentJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Thread.Sleep(3000);
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string testdata = dataMap.GetString("testdata");
            dataMap.Put("testdata", testdata+"1");
            await Console.Error.WriteLineAsync($"testdata：{testdata} time:{DateTime.Now.ToString()}");
        }
    }
}
