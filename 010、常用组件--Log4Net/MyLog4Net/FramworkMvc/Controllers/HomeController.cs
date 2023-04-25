using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FramworkMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            {
                ////默认读取Web.config中的配置
                //XmlConfigurator.Configure();
                ////创建log对象
                //ILog ilog = LogManager.GetLogger(typeof(HomeController));
                ////打印日志
                //ilog.Debug("我打出了Log4Net日志！");
            }

            {
                ////读取特定配置文件
                //XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4Net.config")));
                ////创建log对象
                //ILog ilog = LogManager.GetLogger(typeof(HomeController));
                ////打印日志
                //ilog.Debug("我打出了Log4Net日志！");
            }

            {
                ////AssemblyInfo.cs中配置好配置文件
                ////[assembly: log4net.Config.XmlConfigurator()] // 指定读取默认的配置文件
                ////[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4Net.config")] // 指定读取log4net 的配置文件
                ////创建log对象
                //ILog ilog = LogManager.GetLogger(typeof(HomeController));
                ////打印日志
                //ilog.Debug("我打出了Log4Net日志！");
            }

            {
                //在Global.asax.cs的Application_Start方法中全局配置
                //创建log对象
                ILog ilog = LogManager.GetLogger(typeof(HomeController));
                //打印日志
                ilog.Debug("我打出了Log4Net日志！");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}