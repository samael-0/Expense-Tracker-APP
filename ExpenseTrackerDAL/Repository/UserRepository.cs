using ExpenseTrackerDAL.DataAccess;
using ExpenseTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DapperMvcDemo.Data.DataAccess;
//using DapperMvcDemo.Data.Models.Domain;

namespace ExpenseTrackerDAL.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ISqlDataAccess _db;

        public UserRepository(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<User?> GetUserByEmail(string email)
        {
            string sql = @"SELECT TOP 1 UserId, FullName, Email, Password
                   FROM dbo.users
                   WHERE Email = @Email";

            var result = await _db.GetData<User, dynamic>(sql, new { Email = email });

            return result.FirstOrDefault();
        }





    }
}
