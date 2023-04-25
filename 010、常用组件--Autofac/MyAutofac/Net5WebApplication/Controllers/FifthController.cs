using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Net5WebApplication.Controllers
{
    public class FifthController : Controller
    {
        private IComponentContext _componentContext;

        public FifthController(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
        }

        public IActionResult Index()
        {
            ITestService testServiceA = _componentContext.ResolveNamed<ITestService>("a");
            ITestService testServiceB = _componentContext.ResolveNamed<ITestService>("b");
            object result = $"{testServiceA.Show()}--{testServiceB.Show()}";
            return View(result);
        }
    }
}
