using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class LoanType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Loan Type")]
        
        public string Description { get; set; }
        public int Days { get; set; }

    }
}