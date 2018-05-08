using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public bool IsActivated { get; set; }
    }
}
