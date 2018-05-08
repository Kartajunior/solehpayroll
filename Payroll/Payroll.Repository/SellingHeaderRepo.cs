using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SellingHeaderRepo
    {
        public static List<SellingHeaderViewModel> Get()
        {
            List<SellingHeaderViewModel> result = new List<SellingHeaderViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static SellingHeaderViewModel GetById(int id)
        {
            SellingHeaderViewModel result = new SellingHeaderViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          where d.Id == id
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static Responses Update(SellingHeaderViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SellingHeader sh = db.SellingHeader.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (sh != null)
                        {
                            sh.Reference = entity.Reference;
                            sh.DateOfSelling = entity.DateOfSelling;
                            sh.SellingTotal = entity.SellingTotal;
                            sh.Payment = entity.Payment;
                            sh.IsActivated = entity.IsActivated;
                            sh.ModifyBy = "Sol";
                            sh.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SellingHeader sh = new SellingHeader();
                        sh.Reference = entity.Reference;
                        sh.DateOfSelling = entity.DateOfSelling;
                        sh.SellingTotal = entity.SellingTotal;
                        sh.Payment = entity.Payment;
                        sh.IsActivated = entity.IsActivated;
                        sh.CreateBy = "Sol";
                        sh.CreateDate = DateTime.Now;
                        db.SellingHeader.Add(sh);
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
                    SellingHeader sh = db.SellingHeader.Where(o => o.Id == id).FirstOrDefault();
                    if (sh != null)
                    {
                        db.SellingHeader.Remove(sh);
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