using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class JobPositionViewModel
    {
        public int Id { get; set; }

        [MaxLength(10), Required]
        public string Code { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name ="Department")]
        public string DepartmentCode { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name ="Department")]
        public string DepartmentCodeName
        {
            get
            {
                return "[" + DepartmentCode + "]" + DepartmentName;
            }
        }

        [Display(Name = "Job Position")]
        public string JobCodeName
        {
            get
            {
                return "[" + Code + "]" + Description;
            }
        }

        [MaxLength(50), Required]
        public string Description { get; set; }

        public bool IsActivated { get; set; }
    }
}
