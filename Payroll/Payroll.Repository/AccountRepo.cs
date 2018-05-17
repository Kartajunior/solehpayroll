using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class AccountRepo
    {
        public AccountViewModel CurrentUser;



        public AccountViewModel find(string username)
        {
            AccountViewModel result = new AccountViewModel();



            using (var db = new PayrollContext())
            {
                result = (from u in db.Users
                          where u.Username == username
                          select new AccountViewModel
                          {
                              Id = u.Id,
                              Username = u.Username,
                              Password = u.Password
                          }).FirstOrDefault();
            }

            return result;
        }

        public AccountViewModel login(string username, string password)
        {
            AccountViewModel result = new AccountViewModel();

            password = Crypto.Hash(password);

            using (var db = new PayrollContext())
            {
                result = (from u in db.Users
                          where u.Username == username && u.Password == password
                          select new AccountViewModel
                          {
                              Id = u.Id,
                              Username = u.Username,
                              Password = u.Password
                          }).FirstOrDefault();
            }
            CurrentUser = result;
            return result;
        }


        public static List<PrivilegeFormsViewModel> GetPrivilegeFormsByUsername(string username)
        {
            List<PrivilegeFormsViewModel> result = new List<PrivilegeFormsViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from ua in db.TrUserAccess
                          join ac in db.AccessControl on
                          ua.AccessControlId equals ac.Id
                          join u in db.Users on ua.UserId
                          equals u.Id
                          where u.Username == username
                          select new PrivilegeFormsViewModel
                          {
                              Id = ac.Id,
                              Controller = ac.Controller,
                              Menu = ac.Menu,
                              Icon = ac.Icon
                          }).ToList();
            }
            return result;
        }

        public static AccountViewModel GetAccessRightByRole(string username, string role)
        {
            AccountViewModel result = new AccountViewModel();
            result.Username = username;
            List<string> vroles = new List<string>();
            using (var db = new PayrollContext())
            {
                var roles = (from u in db.Users
                             join ua in db.TrUserAccess on
                             u.Id equals ua.UserId
                             join ac in db.AccessControl on
                             ua.AccessControlId equals ac.Id
                             where u.Username == username && ac.Controller == role
                             select new
                             {
                                 ctrl = ac.Controller
                             }).ToList();

                foreach (var vrole in roles)
                {
                    vroles.Add(vrole.ctrl);
                }
            }
            result.Roles = vroles;
            return result;
        }

        public static AccountViewModel GetAccessRight(string username, string role)
        {
            AccountViewModel result = new AccountViewModel();
            using (var db = new PayrollContext())
            {
                result = (from u in db.Users
                          join ua in db.TrUserAccess on
                          u.Id equals ua.UserId
                          join ac in db.AccessControl on
                          ua.AccessControlId equals ac.Id
                          where u.Username == username && ac.Controller == role
                          select new AccountViewModel
                          {
                              AccessLevel = ua.Right
                          }).FirstOrDefault();
            }
            return result;
        }
    }
}