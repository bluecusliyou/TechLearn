using MyQuartZ.Net.QuartZJob;
using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuartZ.Net
{
    public class AdoJobStoreTest
    {
        public static void Show()
        {
            NameValueCollection pars = new NameValueCollection
            {
                //scheduler名字
                ["quartz.scheduler.instanceName"] = "MyAdoJobStoreScheduler",
                //类型为JobStoreXT,事务
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                //数据源名称
                ["quartz.jobStore.dataSource"] = "QuartzDb",
                //使用mysql的Ado操作代理类
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.MySQLDelegate, Quartz",
                //数据源连接字符串
                ["quartz.dataSource.QuartzDb.connectionString"] = @"server=数据库服务器IP地址;Database=quartzmanager;user id=root;password=123456;SslMode=none;",
                //数据源的数据库
                ["quartz.dataSource.QuartzDb.provider"] = "MySql",
                //序列化类型
                ["quartz.serializer.type"] = "json",
                //自动生成scheduler实例ID，主要为了保证集群中的实例具有唯一标识
                ["quartz.scheduler.instanceId"] = "AUTO",
            };
            //实例化调度器
            ISchedulerFactory schedulefactory = new StdSchedulerFactory(pars);
            IScheduler scheduler = schedulefactory.GetScheduler().Result;

            //开启调度器
            scheduler.Start();

            ////创建一个作业
            //IJobDetail job1 = JobBuilder.Create<MyJob>()
            //    .WithIdentity("job1", "groupa")//名称，分组
            //    .Build();

            ////创建一个触发器
            //ITrigger trigger1 = TriggerBuilder.Create()
            //    .WithIdentity("trigger1", "groupa")//名称，分组
            //    .StartNow()//从启动的时候开始执行
            //    .WithSimpleSchedule(b =>
            //    {
            //        b.WithIntervalInSeconds(2)//2秒执行一次
            //         .RepeatForever();
            //    })
            //    .Build();

            ////把作业，触发器加入调度器
            //scheduler.ScheduleJob(job1, trigger1);
        }
    }
}
