using Quartz;

namespace MyQuartZ.Net.QuartZListener
{
    public class CustomJobListener : IJobListener
    {
        public string Name => "CustomJobListener";

        /// <summary>
        /// 任务执行前
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"【{Name}】-【JobToBeExecuted】-【要执行的任务】");
            await Task.CompletedTask;
        }


        /// <summary>
        /// 任务执行后
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jobException"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"【{Name}】-【JobWasExecuted】-【作业已执行】");
            await Task.CompletedTask;
        }

        /// <summary>
        /// 任务被拒绝执行的时候
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"【{Name}】-【JobExecutionVetoed】-【工作执行被否决】");
            await Task.CompletedTask;
        }
    }
}
