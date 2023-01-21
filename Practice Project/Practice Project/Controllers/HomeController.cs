using Microsoft.AspNetCore.Mvc;
using Practice_Project.Models;
using System.Diagnostics;

namespace Practice_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static  ITestModel? _testModel;
        public HomeController(ILogger<HomeController> logger, ITestModel testModel)
        {
            _logger = logger;
            _testModel = testModel;
        }

        public IActionResult Index()
        {
            ITestModel testModel = new TestModel();
            testModel.Simple();
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