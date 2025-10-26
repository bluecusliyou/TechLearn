using MyQuartZ.Net.QuartZJob;
using Quartz;
using Quartz.Impl.Calendar;

namespace MyQuartZ.Net
{
    public class CalendarTest
    {
        public static void Show()
        {
            {
                //Calendar
                //DailyCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                DailyCalendar calendar = new DailyCalendar(DateBuilder.DateOf(21, 0, 0).DateTime, DateBuilder.DateOf(22, 0, 0).DateTime);

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, true, true);

                //创建一个作业
                var job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //Calendar
                //WeeklyCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                WeeklyCalendar calendar = new WeeklyCalendar();
                calendar.SetDayExcluded(DayOfWeek.Friday, true);

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, true, true);

                //创建一个作业
                var job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //Calendar
                //HolidayCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                HolidayCalendar calendar = new HolidayCalendar();
                calendar.AddExcludedDate(DateTime.Parse("06-16"));//6月16日排除在外

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, false, false);

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //Calendar
                //MonthlyCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                MonthlyCalendar calendar = new MonthlyCalendar();
                calendar.SetDayExcluded(27, true);  //将27号这天排除在外

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, false, false);

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //Calendar
                //AnnualCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                AnnualCalendar calendar = new AnnualCalendar();
                calendar.SetDayExcluded(DateTime.Parse("06-16"), true);  //6月16日排除在外

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, false, false);

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }

            {
                //Calendar
                //CronCalendar
                //实例化调度器
                IScheduler scheduler = MySchedulerFactory.GetScheduler();

                //开启调度器
                scheduler.Start();

                //实例化日历
                CronCalendar calendar = new CronCalendar("* * * 27 2 ?");
                scheduler.AddCalendar("mycalendar", calendar, true, true);//2月27号这天不执行

                //将日历添加到调度器
                scheduler.AddCalendar("mycalendar", calendar, false, false);

                //创建一个作业
                IJobDetail job1 = JobBuilder.Create<MyJob>().Build();

                //创建一个触发器
                ITrigger trigger1 = TriggerBuilder.Create()
                    .StartNow()//从启动的时候开始执行                    
                    .WithSimpleSchedule(b =>
                    {
                        b.WithIntervalInSeconds(2).RepeatForever();//2秒执行一次
                    })
                    .ModifiedByCalendar("mycalendar") // but not on holidays
                    .Build();

                //把作业，触发器加入调度器
                scheduler.ScheduleJob(job1, trigger1);
            }
        }
    }
}
