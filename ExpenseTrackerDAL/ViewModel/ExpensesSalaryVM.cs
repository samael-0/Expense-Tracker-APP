using ExpenseTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.ViewModel
{
    public class ExpensesSalaryVM
    {

        public Salary Salary { get; set; }

        public IEnumerable<Expenses> Expenses { get; set; }

        public Expenses NewExpense { get; set; }

        public string MonthYear { get; set; }
    }
}
