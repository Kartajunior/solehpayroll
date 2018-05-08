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
    public class SalaryComponentsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SalaryComponentViewModel> Get()
        {
            return SalaryComponentRepo.Get();
        }

        // GET api/<controller>/5
        public SalaryComponentViewModel Get(int id)
        {
            return SalaryComponentRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]SalaryComponentViewModel entity)
        {
            return SalaryComponentRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]SalaryComponentViewModel entity)
        {
            entity.Id = id;
            return SalaryComponentRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return SalaryComponentRepo.Delete(id);
        }
    }
}