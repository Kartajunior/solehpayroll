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
    [CustomAuthorize(Roles = "Division")]

    public class DivisionController : Controller
    {
        // GET: Division
        public ActionResult Index()
        {            
            return View();
        }

        //GET LIST
        public ActionResult List()
        {
            return View("_List", DivisionRepo.Get());
        }

        [CustomAuthorize(Roles = "Division", AccessLevel = "W")]
        //GET CREATE
        public ActionResult Create()
        {
            return View("_Create");
        }

        //POST CREATE
        [HttpPost]
        public ActionResult Create(DivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (DivisionRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { succes = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { succes = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { succes = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", DivisionRepo.GetById(id));
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit (DivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (DivisionRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { succes = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { succes = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { succes = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            return View("_Delete", DivisionRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm (int id)
        {
            Responses responses = (DivisionRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }

        //GET DETAILS
        public ActionResult Details(int id)
        {
            return View("_Details", DivisionRepo.GetById(id));
        }
    }
}