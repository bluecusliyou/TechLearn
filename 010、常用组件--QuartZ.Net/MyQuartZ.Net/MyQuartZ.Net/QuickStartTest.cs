using MyQuartZ.Net.QuartZJob;
using Quartz;
using Quartz.Impl;

namespace MyQuartZ.Net
{
    public class QuickStartTest
    {
        public static void Show()
        {
            //简单调度
            //实例化调度器
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;

            //开启调度器
            scheduler.Start();

            //创建一个作业
            IJobDetail job1 = JobBuilder.Create<MyJob>()
                .WithIdentity("job1", "groupa")//名称，分组
                .Build();

            //创建一个触发器
            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity("trigger1", "groupa")//名称，分组
                .StartNow()//从启动的时候开始执行
                .WithSimpleSchedule(b =>
                {
                    b.WithIntervalInSeconds(2)//2秒执行一次
                     .WithRepeatCount(3);//重复执行3+1次
                })
                .Build();

            //把作业，触发器加入调度器
            scheduler.ScheduleJob(job1, trigger1);
        }
    }
}
