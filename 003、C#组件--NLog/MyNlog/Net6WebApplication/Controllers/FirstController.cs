using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Net6WebApplication.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _ILogger;
        private readonly ILoggerFactory _ILoggerFactory;
        public FirstController(ILogger<FirstController> logger, ILoggerFactory iLoggerFactory)
        {
            this._ILogger = logger;
            _ILogger.LogInformation($"{this.GetType().FullName} 被构造。。。。LogInformation");
            _ILogger.LogError($"{this.GetType().FullName} 被构造。。。。LogError");
            _ILogger.LogDebug($"{this.GetType().FullName} 被构造。。。。LogDebug");
            _ILogger.LogTrace($"{this.GetType().FullName} 被构造。。。。LogTrace");
            _ILogger.LogCritical($"{this.GetType().FullName} 被构造。。。。LogCritical");

            this._ILoggerFactory = iLoggerFactory;
            ILogger<FirstController> _ILogger2 = _ILoggerFactory.CreateLogger<FirstController>();
            _ILogger2.LogInformation("这里是通过Factory得到的Logger写的日志");
        }

        public IActionResult Index()
        {
            _ILogger.LogInformation($"{this.GetType().FullName} Index被请求");
            return View();
        }
    }
}
