using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SalaryDefaultValueViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Job Position")]
        public int JobPositionId { get; set; }

        [Display(Name = "Job Position")]
        public string JobName { get; set; }

        [Display(Name = "Salary Component")]
        public int SalaryComponentId { get; set; }

        [Display(Name = "Salary Component")]
        public string SalaryComponentName { get; set; }

        public decimal Value { get; set; }

        public bool IsActivated { get; set; }
    }
}
