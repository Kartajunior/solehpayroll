using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payroll1.API.Controllers
{
    public class EmployeeSalarysController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EmployeeSalaryViewModel> Get()
        {
            return EmployeeSalaryRepo.Get();
        }

        // GET api/<controller>/5
        public EmployeeSalaryViewModel Get(int id)
        {
            return EmployeeSalaryRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]EmployeeSalaryViewModel entity)
        {
            return EmployeeSalaryRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]EmployeeSalaryViewModel entity)
        {
            entity.Id = id;
            return EmployeeSalaryRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return EmployeeSalaryRepo.Delete(id);
        }
    }
}