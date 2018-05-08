using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryComponentRepo
    {
        public static List<SalaryComponentViewModel> Get()
        {
            List<SalaryComponentViewModel> result = new List<SalaryComponentViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static SalaryComponentViewModel GetById(int id)
        {
            SalaryComponentViewModel result = new SalaryComponentViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          where d.Id == id
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(SalaryComponentViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryComponent salarycomponent = db.SalaryComponent.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (salarycomponent != null)
                        {
                            salarycomponent.Code = entity.Code;
                            salarycomponent.Description = entity.Description;
                            salarycomponent.Period = entity.Period;
                            salarycomponent.Type = entity.Type;
                            salarycomponent.IsActivated = entity.IsActivated;
                            salarycomponent.ModifyBy = "Sol";
                            salarycomponent.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryComponent salarycomponent = new SalaryComponent();
                        salarycomponent.Code = entity.Code;
                        salarycomponent.Description = entity.Description;
                        salarycomponent.Period = entity.Period;
                        salarycomponent.Type = entity.Type;
                        salarycomponent.IsActivated = entity.IsActivated;
                        salarycomponent.CreateBy = "Sol";
                        salarycomponent.CreateDate = DateTime.Now;
                        db.SalaryComponent.Add(salarycomponent);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        public static Responses Delete(int id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    SalaryComponent salarycomponent = db.SalaryComponent.Where(o => o.Id == id).FirstOrDefault();
                    if (salarycomponent != null)
                    {
                        db.SalaryComponent.Remove(salarycomponent);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
    }
}
