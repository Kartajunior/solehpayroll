using Payroll.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll1.API
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (var db = new PayrollContext())
            {
                return db.Users.Any(o => o.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && o.Password == password); 
            }
        }
    }
}