using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class Responses
    {
        public Responses()
        {
            Success = true;
            Message = "No message";
        }
        public bool Success { get; set; }

        public string Message { get; set; }

    }
}
