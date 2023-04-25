using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace MyQuartZ.Net
{
    public class ThreadPoolTest
    {
        public static void Show()
        {
            {
                NameValueCollection pars = new NameValueCollection
                {                    
                    //线程池个数20
                    ["quartz.threadPool.threadCount"] = "20"
                };
                ISchedulerFactory schedulefactory = new StdSchedulerFactory(pars);
                IScheduler scheduler = schedulefactory.GetScheduler().Result;
            }

            {
                Environment.SetEnvironmentVariable("quartz.threadPool.threadCount", "26");
                var factory = new StdSchedulerFactory();
                var scheduler = factory.GetScheduler();
            }
        }
    }
}
