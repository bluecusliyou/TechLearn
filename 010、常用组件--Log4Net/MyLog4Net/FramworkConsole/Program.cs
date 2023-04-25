using log4net;
using log4net.Config;

namespace FramworkConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                ////默认读取App.config中的配置
                //XmlConfigurator.Configure();
                ////创建log对象
                //ILog ilog = LogManager.GetLogger(typeof(Program));
                ////打印日志
                //ilog.Debug("我打出了Log4Net日志！");
            }

            {
                ////读取特定配置文件
                //XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4Net.config")));
                ////创建log对象
                //ILog ilog = LogManager.GetLogger(typeof(Program));
                ////打印日志
                //ilog.Debug("我打出了Log4Net日志！");
            }

            {
                //AssemblyInfo.cs中配置好配置文件
                //[assembly: log4net.Config.XmlConfigurator()] // 指定读取默认的配置文件
                //[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4Net.config")] // 指定读取log4net 的配置文件
                //创建log对象
                ILog ilog = LogManager.GetLogger(typeof(Program));
                //打印日志
                ilog.Debug("我打出了Log4Net日志！");
            }
        }
    }
}
