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
        public async Task<IEnumerable<Expenses>> GetAllExpenseBySalaryid(int salaryid)
        {
            string sql = @"SELECT * 
                   FROM Expenses
                   WHERE SalaryId = @salaryID"; ;

            var result = await _db.GetData<Expenses, dynamic>(sql, new { salaryID = salaryid });

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

        public async Task<Salary> GetSalaryByUseridandMonth(int user,string Month)
        {
            string sql = @"SELECT * 
                   FROM Salary
                   WHERE Month=@month AND UserId = @userID" ; ;

            var result = await _db.GetData<Salary, dynamic>(sql, new { userID = user ,month =Month});
             
            return result.FirstOrDefault();
        }


        public async Task<Expenses> AddExpenses(Expenses expenses)
        {
            string sql = @"INSERT INTO Expenses (SalaryId, Title, Amount, ExpenseDate, UserId)
                           VALUES (@SalaryId, @Title, @Amount, @ExpenseDate, @UserId)";

            await _db.SaveData(sql, expenses);

            return expenses;


        }


        public async Task<Salary> AddSalary(Salary Salary)
        {
            string sql = @"INSERT INTO Salary(Month, TotalAmount, RemainingAmount, UserId)
                           VALUES (@month, @totalamount, @remainingamount, @userid)";

            await _db.SaveData(sql,Salary);

            return Salary;
        }
    }
}
