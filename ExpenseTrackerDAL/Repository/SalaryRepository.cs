using ExpenseTrackerDAL.DataAccess;
using ExpenseTrackerDAL.Models;
using ExpenseTrackerDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Repository
{

    public class SalaryRepository : ISalaryRepository
    {

        private readonly ISqlDataAccess _db;

        public SalaryRepository(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Expenses>> GetAllExpenseByUserid(int user)
        {
            string sql = @"SELECT * 
                   FROM Expenses
                   WHERE UserId = @userID"; ;

            var result = await _db.GetData<Expenses, dynamic>(sql, new { userID = user });

            return result;
        }
        public async Task<Salary> GetSalaryByUserid(int user)
        {
            string sql = @"SELECT * 
                   FROM Salary
                   WHERE UserId = @userID"; ;

            var result = await _db.GetData<Salary, dynamic>(sql, new { userID = user });

            return result.FirstOrDefault();
        }


        public async Task<Expenses> AddExpenses(Expenses expenses)
        {
            string sql = @"INSERT INTO Expenses (SalaryId, Title, Amount, ExpenseDate, UserId)
                           VALUES (@SalaryId, @Title, @Amount, @ExpenseDate, @UserId)";

            await _db.SaveData(sql, expenses);

            return expenses;


        }
    }
}
