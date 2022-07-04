using EventTracker_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventTracker_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// methods 
        /// </summary>
        /// <returns></returns>
        /// 
       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudyMaterial()
        {
            //string path = "/Notes From MS - .Net Core.pdf"; // file is placed in wwwroot
            return File("","application/pdf");
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