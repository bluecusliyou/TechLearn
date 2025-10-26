using Quartz;
using Quartz.Impl;

namespace MyQuartZ.Net
{
    public class MySchedulerFactory
    {
        /// <summary>
        /// 由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        /// </summary>
        private static IScheduler _Scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        public static IScheduler GetScheduler()
        {
            return _Scheduler;
        }
    }
}
