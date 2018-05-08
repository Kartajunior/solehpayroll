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
    public class PayrollPeriodsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PayrollPeriodViewModel> Get()
        {
            return PayrollPeriodRepo.Get();
        }

        // GET api/<controller>/5
        public PayrollPeriodViewModel Get(int id)
        {
            return PayrollPeriodRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]PayrollPeriodViewModel entity)
        {
            return PayrollPeriodRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]PayrollPeriodViewModel entity)
        {
            entity.Id = id;
            return PayrollPeriodRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return PayrollPeriodRepo.Delete(id);
        }
    }
}