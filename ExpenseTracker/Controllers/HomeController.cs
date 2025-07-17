using System.Diagnostics;
using ExpenseTracker.Models;
using ExpenseTracker.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [SessionAuthorize]
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("UserEmail") == null)
            //{
            //    // User is not logged in → redirect to login page
            //    return RedirectToAction("Login", "Account");
            //}

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
