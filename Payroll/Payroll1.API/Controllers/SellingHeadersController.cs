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
    public class SellingHeadersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SellingHeaderViewModel> Get()
        {
            return SellingHeaderRepo.Get();
        }

        // GET api/<controller>/5
        public SellingHeaderViewModel Get(int id)
        {
            return SellingHeaderRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]SellingHeaderViewModel entity)
        {
            return SellingHeaderRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]SellingHeaderViewModel entity)
        {
            entity.Id = id;
            return SellingHeaderRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return SellingHeaderRepo.Delete(id);
        }
    }
}