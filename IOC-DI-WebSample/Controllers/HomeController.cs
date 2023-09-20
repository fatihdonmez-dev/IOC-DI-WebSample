using IOC_DI_WebSample.Models;
using IOC_DI_WebSample.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IOC_DI_WebSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonDateService _singletondateService;
        private readonly IScopedDateService _scopeddateService;
        private readonly ITransientDateService _transientdateService;

        public HomeController(ISingletonDateService singletonDateService,IScopedDateService scopedDateService, ITransientDateService transientdateService)
        {
            _singletondateService = singletonDateService;
            _scopeddateService = scopedDateService;
            _transientdateService = transientdateService;
        }

        public IActionResult Index([FromServices] ISingletonDateService singletonDateServiceV2, [FromServices] IScopedDateService scopedDateServiceV2, [FromServices] ITransientDateService transientDateServiceV2)
        {
            ViewBag.SingletonDateFirst = _singletondateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.SingletonDateSecond = singletonDateServiceV2.GetDateTime.TimeOfDay.ToString();

            ViewBag.ScopedDateFirst = _scopeddateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.ScopedDateSecond = scopedDateServiceV2.GetDateTime.TimeOfDay.ToString();

            ViewBag.TransientDateFirst = _transientdateService.GetDateTime.TimeOfDay.ToString();
            ViewBag.TransientDateSecond = transientDateServiceV2.GetDateTime.TimeOfDay.ToString();



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}