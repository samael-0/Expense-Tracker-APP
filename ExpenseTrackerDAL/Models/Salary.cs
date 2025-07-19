using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Models
{
    public class Salary
    {

        public int Id { get; set; }

        public string Month { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal RemainingAmount { get; set; }
        public int UserId { get; set; }

        public string? MonthYear { get; set; }


    }
}

