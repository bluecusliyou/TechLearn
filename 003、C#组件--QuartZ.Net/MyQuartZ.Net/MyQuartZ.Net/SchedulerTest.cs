using MyQuartZ.Net.QuartZJob;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.AdoJobStore;
using Quartz.Impl.Matchers;
using Quartz.Simpl;
using System.Collections.Specialized;

namespace MyQuartZ.Net
{
    public class SchedulerTest
    {
        public static void Show()
        {
            {
                //实例化调度器
                //方式1
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
                //方式2
                ISchedulerFactory schedulefactory = new StdSchedulerFactory();
                IScheduler scheduler2 = schedulefactory.GetScheduler().Result;
                //方式2 传入参数
                NameValueCollection pars = new NameValueCollection
                {
                    //scheduler名字
                    ["quartz.scheduler.instanceName"] = "MySchedulerAdvanced",
                    //线程池个数
                    ["quartz.threadPool.threadCount"] = "20"
                };
                ISchedulerFactory schedulefactory2 = new StdSchedulerFactory(pars);
                IScheduler scheduler3 = schedulefactory2.GetScheduler().Result;
                //方式3
                IScheduler scheduler4 = SchedulerBuilder.Create().BuildScheduler().Result;
                //方式4
                var serializer = new JsonObjectSerializer();
                serializer.Initialize();
                JobStoreTX jobStore = new JobStoreTX
                {
                    DataSource = "default",
                    TablePrefix = "QRTZ_",
                    InstanceId = "AUTO",
                    DriverDelegateType = typeof(MySQLDelegate).AssemblyQualifiedName,
                    ObjectSerializer = serializer,
                };
                DirectSchedulerFactory.Instance.CreateScheduler("myScheduler", "AUTO", new DefaultThreadPool(), jobStore);
                IScheduler scheduler5 = await SchedulerRepository.Instance.Lookup("myScheduler");
            }

            {
                //常用API
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

                //添加作业
                scheduler.AddJob(job1, true);

                //暂停作业
                scheduler.PauseJobs(GroupMatcher<JobKey>.GroupEquals("groupa"));

                //恢复作业
                scheduler.ResumeJobs(GroupMatcher<JobKey>.GroupEquals("groupa"));

                //停止调度
                scheduler.Shutdown();
            }
        }
    }
}
