using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace MyQuartZ.Net
{
    public class ConfigTest
    {
        public static void Show()
        {
            //job和trigger配置在quartz_jobs.xml中
            NameValueCollection pars = new NameValueCollection
            {                
                //配置读取配置文件
                ["quartz.plugin.jobInitializer.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz.Plugins",
                ["quartz.plugin.jobInitializer.fileNames"] = "quartz_jobs.xml",
                ["quartz.plugin.jobInitializer.failOnFileNotFound"] = "true"
            };
            //实例化调度器
            ISchedulerFactory schedulefactory = new StdSchedulerFactory(pars);
            IScheduler scheduler = schedulefactory.GetScheduler().Result;

            //开启调度器
            scheduler.Start();
        }
    }
}
