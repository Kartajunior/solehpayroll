using Payroll.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Payroll.MVC.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string AccessLevel { get; set; }

      
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", Action = "Index" }));
            else
            {
                //AccountRepo ar = new AccountRepo();
                //CustomPrincipal mp = new CustomPrincipal(ar.find(SessionPersister.Username));
                //if (!mp.IsInRole(Roles))

                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));

                CustomPrincipal cp = new CustomPrincipal(AccountRepo.GetAccessRightByRole(SessionPersister.Username, Roles));
                var level = AccountRepo.GetAccessRight(SessionPersister.Username, Roles);

                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                }
                else
                {
                    if (level.AccessLevel != this.AccessLevel && this.AccessLevel != null)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                    }
                }
            }
        }
    }
}