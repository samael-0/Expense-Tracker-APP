using ExpenseTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Repository
{
    public interface IUserRepository
    {

        Task<User?> GetUserByEmail(string email);
    }
}