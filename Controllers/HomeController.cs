using Interview_Schedule_Management.Data;
using Interview_Schedule_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interview_Schedule_Management.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationContext _applicationContext;

        public HomeController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IActionResult Index()
        {
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