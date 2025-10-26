using log4net;
using log4net.Config;

namespace Net6Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //配置文件
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4Net.config")));
            //创建log对象
            ILog ilog = LogManager.GetLogger(typeof(Program));
            //打印日志
            ilog.Debug("我打出了Log4Net日志！");
        }
    }
}