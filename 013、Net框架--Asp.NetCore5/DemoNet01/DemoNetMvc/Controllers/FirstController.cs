using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DemoNet5Mvc.Controllers
{
    public class FirstController : Controller
    {
        public IConfiguration _Configuration { get; }

        /// <summary>
        /// 构造函数注入 
        /// </summary>
        /// <param name="configuration"></param>
        public FirstController(IConfiguration configuration)
        {
            this._Configuration = configuration;
        }

        #region 1、当前页面传值
        /// <summary>
        /// 当前页面传值
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.User1 = "User1";
            ViewData["User2"] = "User2";
            TempData["User3"] = "User3";
            object User4 = "User4";

            //Session
            HttpContext.Session.SetString("User5", "User5");

            //return View(User4);
            ////修改页面的跳转方式
            return RedirectToAction("Second");
        }
        #endregion

        #region 2、跨页面传值
        /// <summary>
        /// 跨页面传值
        /// </summary>
        /// <returns></returns>
        public IActionResult Second()
        {            
            return View();
        }
        #endregion

        #region 获取脚本参数
        /// <summary>
        /// 获取脚本参数
        /// </summary>
        /// <returns></returns>
        public IActionResult Third()
        {
            ViewBag.port = _Configuration["port"];
            return View();
        }
        #endregion
    }
}
