using ExpenseTrackerDAL.Models;
using ExpenseTrackerDAL.Repository;
using ExpenseTrackerDAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class SalaryTransactionController : Controller
    {

        private readonly ISalaryRepository _salaryRepository;

        public SalaryTransactionController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }



        //[HttpGet]
        //public async Task<IActionResult> ExpensePage() { 
        //    return View();
        //}


        [HttpGet]
        public async Task<IActionResult> ExpensePage()
        {

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                ISession session = HttpContext.Session;
                int userId = (int)session.GetInt32("UserId");
                string currentMonth = DateTime.Now.ToString("yyyy-MM");

                var salary = await _salaryRepository.GetSalaryByUseridandMonth(userId,currentMonth);
                var expenses = await _salaryRepository.GetAllExpenseBySalaryid(salary.Id);
                

                var expensesSalaryVM = new ExpensesSalaryVM
                {
                    Salary = salary,
                    Expenses = expenses,
                    NewExpense = new Expenses()
                };
                return View(expensesSalaryVM);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult>ExpensePageBySalary(string month)
        {

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                ISession session = HttpContext.Session;
                int userId = (int)session.GetInt32("UserId");

                var salary = await _salaryRepository.GetSalaryByUseridandMonth(userId, month);
                if (salary != null)
                {
                    var expenses = await _salaryRepository.GetAllExpenseBySalaryid(salary.Id);


                    var expensesSalaryVM = new ExpensesSalaryVM
                    {
                        Salary = salary,
                        Expenses = expenses,
                        NewExpense = new Expenses()
                    };
                    return View("ExpensePage", expensesSalaryVM);
                }
                else
                {
                    TempData["message"] = "No salary found for the selected month.";
                    return RedirectToAction("ExpensePage");


                }
                

            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> ExpensePageBySalaryGET(string month)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int userId = (int)HttpContext.Session.GetInt32("UserId");

                var salary = await _salaryRepository.GetSalaryByUseridandMonth(userId, month);
                var expenses = await _salaryRepository.GetAllExpenseBySalaryid(salary.Id);

                var expensesSalaryVM = new ExpensesSalaryVM
                {
                    Salary = salary,
                    Expenses = expenses,
                    NewExpense = new Expenses()
                };
                return View("ExpensePage", expensesSalaryVM);
            }

            return RedirectToAction("Login", "Account");
        }




        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpensesSalaryVM expensesSalaryVM)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            //if (!ModelState.IsValid)
            //{
            //    expensesSalaryVM.Salary = await _salaryRepository.GetSalaryByUserid(userId);
            //    expensesSalaryVM.Expenses = await _salaryRepository.GetAllExpenseByUserid(userId);
            //    return View("ExpensePage", expensesSalaryVM);
            //}

            var salary = await _salaryRepository.GetSalaryByUseridandMonth(userId, expensesSalaryVM.Salary.Month);

            expensesSalaryVM.NewExpense.UserId = userId;
            expensesSalaryVM.NewExpense.SalaryId = salary.Id;  // Assign SalaryId here
            //expensesSalaryVM.NewExpense.ExpenseDate = DateTime.Now;

            await _salaryRepository.AddExpenses(expensesSalaryVM.NewExpense);

            return RedirectToAction("ExpensePageBySalaryGET", new { month = expensesSalaryVM.Salary.Month });
        }


        [HttpGet]

        public async Task<IActionResult>AddSalary()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> AddSalary(ExpensesSalaryVM expensesalaryVM)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            expensesalaryVM.Salary.UserId = userId;
            expensesalaryVM.Salary.RemainingAmount = expensesalaryVM.Salary.TotalAmount;
            expensesalaryVM.Salary.Month = expensesalaryVM.Salary.MonthYear;

            await _salaryRepository.AddSalary(expensesalaryVM.Salary);
            return RedirectToAction("ExpensePage");
        }

    }
}


