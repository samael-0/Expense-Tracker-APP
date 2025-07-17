using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int SalaryId { get; set; }

        public string? Title { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }


    }
}
