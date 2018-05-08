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
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EmployeeViewModel> Get()
        {
            return EmployeeRepo.Get();
        }

        // GET api/<controller>/5
        public EmployeeViewModel Get(int id)
        {
            return EmployeeRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]EmployeeViewModel entity)
        {
            return EmployeeRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]EmployeeViewModel entity)
        {
            entity.Id = id;
            return EmployeeRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return EmployeeRepo.Delete(id);
        }
    }
}