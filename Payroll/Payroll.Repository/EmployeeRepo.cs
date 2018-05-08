using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class EmployeeRepo
    {
        public static List<EmployeeViewModel> Get()
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobName = jp.Description,
                              JobCode = jp.Code,
                              JobPositionId = d.JobPositionId,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static EmployeeViewModel GetById(int id)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          where d.Id == id
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobName = jp.Description,
                              JobCode = jp.Code,
                              JobPositionId = d.JobPositionId,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static EmployeeViewModel GetByBadgeId(string badgeId)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          where d.BadgeId == badgeId
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobName = jp.Description,
                              JobCode = jp.Code,
                              JobPositionId = d.JobPositionId,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<EmployeeViewModel> GetBySearching(string search)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Employee
                          join jp in db.JobPosition on
                          d.JobPositionId equals jp.Id
                          where d.Id.ToString().Contains(search) || d.BadgeId.Contains(search) || d.FirstName.Contains(search)
                         || d.MiddleName.Contains(search) || d.LastName.Contains(search) || jp.Description.Contains(search)
                          select new EmployeeViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              JobName = jp.Description,
                              JobCode = jp.Code,
                              JobPositionId = d.JobPositionId,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              LastName = d.LastName,
                              Address = d.Address,
                              DateOfHire = d.DateOfHire,
                              DateOfResign = d.DateOfResign,
                              PlaceOfBirth = d.PlaceOfBirth,
                              DateOfBirth = d.DateOfBirth,
                              Gender = d.Gender,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

      

        public static Responses Update(EmployeeViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                       Employee employee = db.Employee.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (employee != null)
                        {
                            employee.BadgeId = entity.BadgeId;
                            employee.BadgeId = entity.BadgeId;
                            employee.JobPositionId = entity.JobPositionId;
                            employee.FirstName = entity.FirstName;
                            employee.MiddleName = entity.MiddleName;
                            employee.LastName = entity.LastName;
                            employee.Address = entity.Address;
                            employee.DateOfHire = entity.DateOfHire;
                            employee.DateOfResign = entity.DateOfResign;
                            employee.PlaceOfBirth = entity.PlaceOfBirth;
                            employee.DateOfBirth = entity.DateOfBirth;
                            employee.Gender = entity.Gender;
                            employee.IsActivated = entity.IsActivated;
                            employee.ModifyBy = "sol";
                            employee.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Employee employee = new Employee();
                        employee.BadgeId = entity.BadgeId;
                        employee.BadgeId = entity.BadgeId;
                        employee.JobPositionId = entity.JobPositionId;
                        employee.FirstName = entity.FirstName;
                        employee.MiddleName = entity.MiddleName;
                        employee.LastName = entity.LastName;
                        employee.Address = entity.Address;
                        employee.DateOfHire = entity.DateOfHire;
                        employee.DateOfResign = entity.DateOfResign;
                        employee.PlaceOfBirth = entity.PlaceOfBirth;
                        employee.DateOfBirth = entity.DateOfBirth;
                        employee.Gender = entity.Gender;
                        employee.IsActivated = entity.IsActivated;
                        employee.CreateBy = "Sol";
                        employee.CreateDate = DateTime.Now;
                        db.Employee.Add(employee);
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
                    Employee employee = db.Employee.Where(o => o.Id == id).FirstOrDefault();
                    if (employee != null)
                    {
                        db.Employee.Remove(employee);
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
