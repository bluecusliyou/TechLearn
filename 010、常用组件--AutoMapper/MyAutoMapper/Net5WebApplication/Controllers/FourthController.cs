using Microsoft.AspNetCore.Mvc;
using Net5WebApplication.AutoMapper;

namespace Net5WebApplication.Controllers
{
    public class FourthController : Controller
    {
        private IUserService _userService;
        public FourthController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            object result = this._userService.Login("username", "password");
            return View(result);
        }
    }
}
