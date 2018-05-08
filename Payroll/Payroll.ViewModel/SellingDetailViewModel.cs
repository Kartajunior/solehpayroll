using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class SellingDetailViewModel
    {
        public int Id { get; set; }
        public int SellingHeaderId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public bool IsActivated { get; set; }
    }
}
