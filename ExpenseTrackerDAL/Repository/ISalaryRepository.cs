using ExpenseTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Repository
{
    public interface ISalaryRepository
    {

        Task<IEnumerable<Expenses>> GetAllExpenseByUserid(int user);
        Task<Salary> GetSalaryByUserid(int user);
        Task<Expenses> AddExpenses(Expenses expenses);
    }
}