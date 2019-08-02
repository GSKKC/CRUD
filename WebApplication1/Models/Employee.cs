using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        public decimal Salary { get; set; }

        [Display(Name ="Last Update")]
        public DateTime Date { get; set; }

        [Display(Name ="CalCulated Salary")]
        public decimal CalculatedSalary { get; set; }

        [Required(ErrorMessage = "This Field is Mandatory")]
        [Display(Name ="Years In Adapty")]
        public double YearsInAdapty { get; set; }
    }
}