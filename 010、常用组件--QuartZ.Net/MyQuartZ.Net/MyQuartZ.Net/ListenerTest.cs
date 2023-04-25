using MyQuartZ.Net.QuartZJob;
using MyQuartZ.Net.QuartZListener;
using Quartz;

namespace MyQuartZ.Net
{
    public class ListenerTest
    {
        public static void Show()
        {
            {
                //trigger监听器
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

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
                        b.WithIntervalInSeconds(2);//2秒执行一次
                    })
                    .Build();

                //将trigger监听器注册到调度器
                scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //job监听器
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

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
                        b.WithIntervalInSeconds(2);//2秒执行一次
                    })
                    .Build();

                //将job监听器注册到调度器
                scheduler.ListenerManager.AddJobListener(new CustomJobListener());

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }
        }
    }
}
