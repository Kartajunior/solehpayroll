using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class DivisionRepo
    {
        public static List<DivisionViewModel> Get()
        {
            List<DivisionViewModel> result = new List<DivisionViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Division
                          select new DivisionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static DivisionViewModel GetById(int id)
        {
            DivisionViewModel result = new DivisionViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Division
                          where d.Id == id
                          select new DivisionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();                          
            }
            return result;
        }

        public static Responses Update(DivisionViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Division division = db.Division.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (division != null)
                        {
                            division.Code = entity.Code;
                            division.Description = entity.Description;
                            division.IsActivated = entity.IsActivated;
                            division.ModifyBy = "Sol";
                            division.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Division division = new Division();
                        division.Code = entity.Code;
                        division.Description = entity.Description;
                        division.IsActivated = entity.IsActivated;
                        division.CreateBy = "Sol";
                        division.CreateDate = DateTime.Now;
                        db.Division.Add(division);
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
                    Division division = db.Division.Where(o => o.Id == id).FirstOrDefault();
                    if (division != null)
                    {
                        db.Division.Remove(division);
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
