using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class DivisionViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActivated { get; set; }
    }
}
