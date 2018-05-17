using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Payroll.ViewModel;
using Payroll.Repository;

namespace Payroll.MVC.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private AccountViewModel Account;
        //private AccountRepo ac = new AccountRepo();

        public CustomPrincipal(AccountViewModel account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Username);
        }

        public IIdentity Identity
        {
            get;
            set;
            
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            
            return roles.Any(r => this.Account.Roles.Contains(r));

        }


    }
}