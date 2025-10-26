using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;

namespace MyQuartZ.Net
{
    public  class ClusterTest
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
                //添加一个开启集群的配置，默认是不开启的
                ["quartz.jobStore.clustered"] = "true"
            };
            //实例化调度器
            ISchedulerFactory schedulefactory = new StdSchedulerFactory(pars);
            IScheduler scheduler = schedulefactory.GetScheduler().Result;

            //开启调度器
            scheduler.Start();
        }
    }
}
