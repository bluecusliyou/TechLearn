using NLog;
using System;

namespace MyNlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //1、代码进行配置
                ////创建一个配置文件对象
                //var config = new NLog.Config.LoggingConfiguration();
                ////创建日志写入目的地
                //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $"logs/{DateTime.Now.ToString("yyyy-MM-dd")}.txt" };
                ////添加日志路由规则
                //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                ////配置文件生效
                //LogManager.Configuration = config;
                ////创建日志记录对象方式1
                //Logger Logger = LogManager.GetCurrentClassLogger();
                ////创建日志记录对象方式2，手动命名
                //Logger Logger2 = LogManager.GetLogger("MyLogger");
                ////打出日志
                //Logger.Debug("我打出了Nlog日志！");
            }

            {
                //2、支持配置文件
                ////创建日志记录对象
                //Logger Logger = NLog.LogManager.GetCurrentClassLogger();
                ////打出日志
                //Logger.Debug("我打出了Nlog日志！");
            }
            {
                //3、输出到不同的存储介质并控制日志文件大小
                //Logger Logger = NLog.LogManager.GetCurrentClassLogger();
                //for (int i = 0; i < 10_000; i++)
                //{
                //    Logger.Debug($"我打出了Nlog日志！--{i.ToString()}");
                //}
            }

            {
                //4、输出到数据库
                //创建日志记录对象
                Logger Logger = NLog.LogManager.GetCurrentClassLogger();
                //打出日志
                Logger.Debug("我打出了Nlog日志！");
            }
        }
    }
}
