using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class SalaryDefaultValueController : Controller
    {
        // GET: SalaryComponent
        public ActionResult Index()
        {
            return View();
        }

        //GET LIST
        public ActionResult List()
        {            
            return View("_List", SalaryDefaultValueRepo.Get());
        }

        //GET CREATE
        public ActionResult Create()
        {
            ViewBag.JobPositionList = new SelectList(JobPositionRepo.Get(), "Id", "Description");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        //POST CREATE
        [HttpPost]
        public ActionResult Create(SalaryDefaultValueViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (SalaryDefaultValueRepo.Update(model));
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
            ViewBag.JobPositionList = new SelectList(JobPositionRepo.Get(), "Id", "Description");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Edit", SalaryDefaultValueRepo.GetById(id));
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit(SalaryDefaultValueViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = (SalaryDefaultValueRepo.Update(model));
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
            return View("_Delete", SalaryDefaultValueRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = (SalaryDefaultValueRepo.Delete(id));
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }

    }
}