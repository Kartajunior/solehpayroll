using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string BadgeId { get; set; }
        public Nullable<System.DateTime> CheckIn { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
        public bool IsActivated { get; set; }
    }
}
