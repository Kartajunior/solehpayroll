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
    public class SellingDetailsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SellingDetailViewModel> Get()
        {
            return SellingDetailRepo.Get();
        }

        // GET api/<controller>/5
        public SellingDetailViewModel Get(int id)
        {
            return SellingDetailRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]SellingDetailViewModel entity)
        {
            return SellingDetailRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]SellingDetailViewModel entity)
        {
            entity.Id = id;
            return SellingDetailRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return SellingDetailRepo.Delete(id);
        }
    }
}