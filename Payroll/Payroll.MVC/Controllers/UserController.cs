using Payroll.DataModel;
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
    public class UserController : Controller
    {
        //// GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // registration Action 
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

       
        [NonAction]
        public bool IsUserXsist(string user)
        {
            return UserRepo.UserXsist(user);
        }

        // registration Post Action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserViewModel user)
        {
            bool Status = false;
            string Message = "";

            //model validation
            if (ModelState.IsValid)
            {
                //user exist
                var isExist = IsUserXsist(user.Username);
                if (isExist)
                {
                    ModelState.AddModelError("EserXsist", "user already exsist");
                    return View (User);
                }

                //password hasing

                user.Password = Crypto.Hash(user.Password);

                Responses responses = UserRepo.Update(user);
                if (responses.Success)
                {
                    return RedirectToAction("Login", "User");

                }
                else
                {
                    return Json(new { succes = false, message = responses.Message}, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                Message = "Invalid Request";
            }

            return View(User);
        }

        //Verif email 

        //verif email link

        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl="")
        {
            string message = "";
            using (var db = new PayrollContext())
            {
                var v = db.Users.Where(o => o.Username == login.Username).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.Username, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "JobPosition");
                        }
                    }
                }
            }
            ViewBag.Message = message;
            return View();
        }


        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

    }
}