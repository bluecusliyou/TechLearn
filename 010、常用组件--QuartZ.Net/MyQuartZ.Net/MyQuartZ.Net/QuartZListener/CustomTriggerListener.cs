using Quartz;

namespace MyQuartZ.Net.QuartZListener
{
    public class CustomTriggerListener : ITriggerListener
    {
        public string Name => "CustomTriggerListener";

        /// <summary>
        /// 触发
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {

            Console.WriteLine("【***************************************************************************************************************】");
            Console.WriteLine($"【{Name}】---【TriggerFired】-【触发】");
            await Task.CompletedTask;
        }

        /// <summary>
        /// 判断作业是否继续
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default)
        {

            Console.WriteLine($"【{Name}】---【VetoJobExecution】-【判断作业是否继续】-{true}");
            return await Task.FromResult(cancellationToken.IsCancellationRequested);
        }


        /// <summary>
        /// 触发完成
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="context"></param>
        /// <param name="triggerInstructionCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"【{Name}】---【TriggerComplete】-【触发完成】");
            await Task.CompletedTask;
        }

        /// <summary>
        /// 触发作业
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"【{Name}】---【TriggerMisfired】【触发作业】");
            await Task.CompletedTask;
        }
    }
}
