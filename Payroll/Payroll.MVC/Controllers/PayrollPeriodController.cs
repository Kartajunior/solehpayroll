using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class PayrollPeriodController : Controller
    {
        // GET: PayrollPeriod
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectPeriod()
        {
            return PartialView("_SelectPeriod", PayrollPeriodRepo.Get());
        }
        [HttpPost]
        public ActionResult SelectedPeriod(int id)
        {
            if (PayrollPeriodRepo.SelectPeriod(id) )
            {
                return Json(new { success = true, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult List()
        {
            return View("_List", PayrollPeriodRepo.Get());
        }

        public ActionResult Create()
        {
            return View("_Create");
        }
        
        //POST CREATE
        [HttpPost]
        public ActionResult Create(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (PayrollPeriodRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET Edit
        public ActionResult Edit(int id)
        {
            
            return View("_Edit", PayrollPeriodRepo.GetById(id));
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (PayrollPeriodRepo.Update(model));
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            return View("_Delete", PayrollPeriodRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (PayrollPeriodRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }

        
    }
}