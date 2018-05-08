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
    public class JobPositionsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<JobPositionViewModel> Get()
        {
            return JobPositionRepo.Get();
        }

        // GET api/<controller>/5
        public JobPositionViewModel Get(int id)
        {
            return JobPositionRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]JobPositionViewModel entity)
        {
            return JobPositionRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]JobPositionViewModel entity)
        {
            entity.Id = id;
            return JobPositionRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return JobPositionRepo.Delete(id);
        }
    }
}