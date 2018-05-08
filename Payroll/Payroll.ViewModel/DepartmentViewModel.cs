using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [MaxLength(10), Required]
        public string Code { get; set; }

        [Display(Name = "Division")] //DIPAKAI UNTUK MODAL FORM CREATE UPDATE
        public int DivisionId { get; set; }//OTOMATIS REQUIRED KARENA 'INT'

        [Display(Name = "Division")] //DIPAKAI UNTUK LIST
        public string DivisionCode { get; set; }

        [Display(Name = "Division")] //DIPAKAI UNTUK LIST
        public string DivisionName { get; set; }

        [Display(Name = "Division")] //DIPAKAI UNTUK LIST
        public string DivisionCodeName
        {
            get
            {
                return "[" + DivisionCode + "] " + DivisionName;
            }
        }

        [Display(Name = "Department")]
        public string DepartmentCodeName
        {
            get
            {
                return "[" + Code + "] " + Description;
            }
        }

        [MaxLength(50), Required]
        public string Description { get; set; }

        public bool IsActivated { get; set; }
    }
}
