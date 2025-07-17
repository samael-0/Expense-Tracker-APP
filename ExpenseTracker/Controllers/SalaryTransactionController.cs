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


                var expenses = await _salaryRepository.GetAllExpenseByUserid(userId);
                var salary = await _salaryRepository.GetSalaryByUserid(userId);

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

            var salary = await _salaryRepository.GetSalaryByUserid(userId);

            expensesSalaryVM.NewExpense.UserId = userId;
            expensesSalaryVM.NewExpense.SalaryId = salary.Id;  // Assign SalaryId here
            expensesSalaryVM.NewExpense.ExpenseDate = DateTime.Now;

            await _salaryRepository.AddExpenses(expensesSalaryVM.NewExpense);

            return RedirectToAction("ExpensePage");
        }


    }
}


