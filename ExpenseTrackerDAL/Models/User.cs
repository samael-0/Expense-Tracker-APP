﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDAL.Models
{
    public class User
    {

        public int UserId { get; set; }
        [Required]

        public string? FullName { get; set; }
        [Required]

        public string? Email { get; set; }

        public string? Password { get; set; }



    }
}