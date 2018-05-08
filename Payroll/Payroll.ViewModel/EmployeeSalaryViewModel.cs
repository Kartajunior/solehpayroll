using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class EmployeeSalaryViewModel
    {
        public int Id { get; set; }
        public string BadgeId { get; set; }
        public int PayrollPeriodId { get; set; }
        public int SalaryComponentId { get; set; }

        [Display(Name="Code")]
        public string SalaryComponentCode { get; set; }

        [Display(Name = "Salary Component Name")]
        public string SalaryComponentName { get; set; }

        public decimal BasicValue { get; set; }
        public decimal FinalValue { get; set; }
        public bool IsActivated { get; set; }
    }
}
