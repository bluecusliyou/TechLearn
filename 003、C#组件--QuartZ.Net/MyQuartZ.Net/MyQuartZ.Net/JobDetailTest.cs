using MyQuartZ.Net.QuartZJob;
using Quartz;
using System.Reflection;

namespace MyQuartZ.Net
{
    public class JobDetailTest
    {
        public static void Show()
        {
            {
                //IJobDetail两种创建方式
                //方式1
                IJobDetail job1 = JobBuilder.Create<MyJob>()
                    .WithIdentity("job1", "groupa")//名称，分组
                    .Build();

                //方式2
                var type = Assembly.Load("MyQuartZ.Net.QuartZJob").CreateInstance("MyJob");
                IJobDetail job2 = JobBuilder.Create().OfType(type.GetType())
                    .WithIdentity("job2", "groupa")//名称，分组
                    .Build();
            }

            {
                //调度传入参数
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<DumbJob>()
                    .WithIdentity("job1", "groupa")//名称，分组
                    .UsingJobData("jobSays", "Hello World!")
                    .UsingJobData("myFloatValue", 3.141f)
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

            {
                //状态更新和并发
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<ConcurrentJob>()
                    .WithIdentity("job1", "groupa")//名称，分组
                    .UsingJobData("testdata", "Hello World!")
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
}
