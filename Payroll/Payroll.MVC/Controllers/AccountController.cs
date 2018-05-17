using Payroll.MVC.Security;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Payroll.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountRepo am = new AccountRepo();
            if (string.IsNullOrEmpty(avm.Username) || string.IsNullOrEmpty(avm.Password) || am.login(avm.Username, avm.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }

            
            var authticket = new FormsAuthenticationTicket(1, avm.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, "");
            string encryptedTicket = FormsAuthentication.Encrypt(authticket);
            var authhCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authhCookie);



            SessionPersister.Username = avm.Username;
            return RedirectToAction("","Home");
            
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}