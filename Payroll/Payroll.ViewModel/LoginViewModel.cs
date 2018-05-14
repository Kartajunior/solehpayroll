using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class LoginViewModel
    {

        [Display(Name = "Username"), Required(AllowEmptyStrings =false, ErrorMessage ="Username Required")] 
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
