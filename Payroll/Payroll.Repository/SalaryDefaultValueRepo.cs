using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryDefaultValueRepo
    {
        public static List<SalaryDefaultValueViewModel> Get()
        {
            List<SalaryDefaultValueViewModel> result = new List<SalaryDefaultValueViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          join sc in db.SalaryComponent on
                          d.SalaryComponentId equals sc.Id
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobName = jp.Description,
                              JobPositionId = d.JobPositionId,
                              SalaryComponentName = sc.Description,
                              SalaryComponentId = d.SalaryComponentId,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static SalaryDefaultValueViewModel GetById(int id)
        {
            SalaryDefaultValueViewModel result = new SalaryDefaultValueViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          join sc in db.SalaryComponent on
                          d.SalaryComponentId equals sc.Id
                          where d.Id == id
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobName = jp.Description,
                              JobPositionId = d.JobPositionId,
                              SalaryComponentName = sc.Description,
                              SalaryComponentId = d.SalaryComponentId,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(SalaryDefaultValueViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryDefaultValue sdv = db.SalaryDefaultValue.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (sdv != null)
                        {
                            sdv.JobPositionId = entity.JobPositionId;
                            sdv.SalaryComponentId = entity.SalaryComponentId;
                            sdv.Value = entity.Value;
                            sdv.IsActivated = entity.IsActivated;
                            sdv.ModifyBy = "Sol";
                            sdv.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryDefaultValue sdv = new SalaryDefaultValue();
                        sdv.JobPositionId = entity.JobPositionId;
                        sdv.SalaryComponentId = entity.SalaryComponentId;
                        sdv.Value = entity.Value;
                        sdv.IsActivated = entity.IsActivated;
                        sdv.CreateBy = "Sol";
                        sdv.CreateDate = DateTime.Now;
                        db.SalaryDefaultValue.Add(sdv);
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
                    SalaryDefaultValue sdv = db.SalaryDefaultValue.Where(o => o.Id == id).FirstOrDefault();
                    if (sdv != null)
                    {
                        db.SalaryDefaultValue.Remove(sdv);
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
