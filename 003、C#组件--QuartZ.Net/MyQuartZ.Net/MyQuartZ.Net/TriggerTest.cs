using MyQuartZ.Net.QuartZJob;
using Quartz;
using Quartz.Listener;

namespace MyQuartZ.Net
{
    public class TriggerTest
    {
        public static void Show()
        {
            {
                //trigger的四种策略
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
                               //策略1：间隔时间重复执行
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2)//2秒执行一次
                         .WithRepeatCount(3);//重复执行3+1次
                    })
                    //策略2：日历间隔时间表
                    .WithCalendarIntervalSchedule(x =>
                    {
                        x.WithIntervalInSeconds(3);//每3秒执行一次
                    })
                    //策略3：时间单位中的几个时间节点
                    .WithDailyTimeIntervalSchedule(x =>
                    {
                        x.OnDaysOfTheWeek(new DayOfWeek[] { DayOfWeek.Thursday, DayOfWeek.Friday }) //周四和周五
                         .StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(8, 00, 00)) //8点开始
                         .EndingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(20, 00, 00))  //20点结束
                         .WithIntervalInSeconds(2)                                       //两秒执行一次，可设置时分秒维度
                         .WithRepeatCount(3);  //一共执行3+1次
                    })
                    //策略4：Cron表达式
                    .WithCronSchedule("0/3 * * * * ?")//每隔3秒执行一次
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                ////触发器优先级
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
                    .WithPriority(10)//设置优先级，默认5，数值越大优先级越高
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2);//2秒执行一次
                    })
                    .Build();


                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //job和trigger关联问题
                //1个job对应1个trigger
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
                        b.WithIntervalInSeconds(2)//2秒执行一次
                         .WithRepeatCount(3);//重复执行3+1次
                    })
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //job和trigger关联问题
                //1个job对应2个trigger
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<MyJob>()
                    .WithIdentity("job1", "groupa")//名称，分组
                    .StoreDurably(true)//持久化job
                    .Build();

                //创建一个触发器1
                ITrigger trigger1 = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "groupa")//名称，分组
                    .StartNow()//从启动的时候开始执行
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2)//2秒执行一次
                         .WithRepeatCount(3);//重复执行3+1次
                    })
                    .ForJob("job1", "groupa")//通过表名和组名进行关联
                    .Build();

                //创建一个触发器2
                ITrigger trigger2 = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "groupa")//名称，分组
                    .StartNow()//从启动的时候开始执行
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2)//2秒执行一次
                         .WithRepeatCount(3);//重复执行3+1次
                    })
                    .ForJob(job1)//直接IJobDetail关联
                    .Build();

                //把作业，触发器加入调度器
                scheduler.AddJob(job1, true);
                scheduler.ScheduleJob(trigger1);
                scheduler.ScheduleJob(trigger2);
            }

            {
                //job和trigger关联问题
                //2个job对应1个trigger
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //创建一个作业1
                IJobDetail job1 = JobBuilder.Create<MyJob>()
                    .WithIdentity("job1", "groupa")//名称，分组
                    .Build();

                //创建一个作业1
                IJobDetail job2 = JobBuilder.Create<MyJob>()
                    .WithIdentity("job2", "groupa")//名称，分组
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
                    .ForJob("job1", "groupa")//通过表名和组名进行关联
                    .Build();

                //创建监听，添加到调度器
                JobChainingJobListener listener = new JobChainingJobListener("mytest");
                listener.AddJobChainLink(job1.Key, job2.Key);
                scheduler.ListenerManager.AddJobListener(listener);

                //把作业，触发器加入调度器
                scheduler.AddJob(job2, true);
                scheduler.ScheduleJob(job1, trigger1);
            }
        }
    }
}
