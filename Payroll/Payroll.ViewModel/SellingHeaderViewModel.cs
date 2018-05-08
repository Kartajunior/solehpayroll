using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SellingHeaderViewModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public System.DateTime DateOfSelling { get; set; }
        public decimal SellingTotal { get; set; }
        public decimal Payment { get; set; }
        public bool IsActivated { get; set; }
    }
}
