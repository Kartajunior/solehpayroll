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
    public class SalaryDefaultValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SalaryDefaultValueViewModel> Get()
        {
            return SalaryDefaultValueRepo.Get();
        }

        // GET api/<controller>/5
        public SalaryDefaultValueViewModel Get(int id)
        {
            return SalaryDefaultValueRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]SalaryDefaultValueViewModel entity)
        {
            return SalaryDefaultValueRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]SalaryDefaultValueViewModel entity)
        {
            entity.Id = id;
            return SalaryDefaultValueRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return SalaryDefaultValueRepo.Delete(id);
        }
    }
}