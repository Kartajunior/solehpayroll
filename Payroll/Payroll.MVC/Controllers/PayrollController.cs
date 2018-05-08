using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class PayrollController : Controller
    {
        // GET: Payroll
        public ActionResult Index()
        {
            PayrollPeriodViewModel period = PayrollPeriodRepo.SelectedPeriod;
            if (period != null )
            {
                if (period.Id > 0)
                {
                    return View();
                }
                
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EmployeeInfo(string badgeId)
        {
            EmployeeViewModel employee = EmployeeRepo.GetByBadgeId(badgeId);
            if (employee == null)
            {
                employee = new EmployeeViewModel();

            }
            return PartialView("_EmployeeInfo", employee);
        }

        public ActionResult EmployeeExist(string badgeId)
        {
            EmployeeViewModel employee = EmployeeRepo.GetByBadgeId(badgeId);
            if (employee != null)
            {
                return Json(new { Exist = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { Exist = false }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult EmployeeList(string searching)
        {
            return PartialView("_EmployeeList", EmployeeRepo.GetBySearching(searching));
        }

        public ActionResult EmployeePayroll(string badgeId)
        {
            List <EmployeeSalaryViewModel> empSalary = EmployeeSalaryRepo.GetByBadgeId(badgeId);
            return PartialView("_EmployeePayroll", empSalary) ;
        }

        public ActionResult SalaryComponentList()
        {
            return PartialView("_SalaryComponentList", SalaryComponentRepo.Get());
        }

        //buat ambil value di payroll
        public ActionResult GetSalaryComponent(int jobPositionId, int salaryComponentId)
        {
            EmployeeSalaryViewModel model = EmployeeSalaryRepo.GetByComponentId(salaryComponentId);
            SalaryDefaultValueViewModel sd = SalaryDefaultValueRepo.GetByJobPositionId(jobPositionId, salaryComponentId);
            if (sd != null)
            {
                model.BasicValue = sd.Value;
            }
            return PartialView("_GetSalaryComponent", model);
        }

        [HttpPost]
        public ActionResult SavePayroll(List<EmployeeSalaryViewModel> models)
        {
            Responses responses = EmployeeSalaryRepo.SaveSalary(models);

            return Json(new { response = responses }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RemoveComponent(string bId, int scId)
        {
            List<EmployeeSalaryViewModel> models = EmployeeSalaryRepo.GetByBadgeId(bId, scId);
            if (models.Count > 0)
            {
                EmployeeSalaryViewModel model = models[0];
                return PartialView("_RemoveComponent", model);
            }
            return PartialView("_RemoveComponent", new EmployeeSalaryViewModel());
        }

        [HttpPost]
        public ActionResult RemoveConfirm(int id)
        {
            Responses responses = EmployeeSalaryRepo.RemoveByComponentId(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        }

    }
}