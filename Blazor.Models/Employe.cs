using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

    }
}
