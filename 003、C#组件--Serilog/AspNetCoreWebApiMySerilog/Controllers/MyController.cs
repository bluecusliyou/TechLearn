using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiMySerilog.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;

        public MyController(ILogger<MyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogDebug("这是一条调试消息");
            _logger.LogInformation("这是一条提示消息");
            _logger.LogWarning("这是一条警告消息");
            _logger.LogError("这是一条错误消息");
            _logger.LogCritical("这是一条严重错误");
            return Ok("Hello World");
        }
    }
}
