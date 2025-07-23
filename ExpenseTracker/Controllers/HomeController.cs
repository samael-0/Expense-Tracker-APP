using System.Diagnostics;
using ExpenseTracker.Models;
using ExpenseTracker.Filters;
using ExpenseTrackerDAL.Repository;
using ExpenseTrackerDAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalaryRepository _salaryRepository;

        public HomeController(ILogger<HomeController> logger, ISalaryRepository salaryRepository)
        {
            _logger = logger;
            _salaryRepository = salaryRepository;
        }

        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string currentMonth = DateTime.Now.ToString("yyyy-MM");
            var salary = await _salaryRepository.GetSalaryByUseridandMonth(userId.Value, currentMonth);

            // You might want to handle the case if salary is null, e.g. no salary found for this month

            return View(salary); // send Salary object directly as model
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
