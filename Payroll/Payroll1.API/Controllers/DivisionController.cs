using Payroll.DataModel;
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
    public class DivisionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<DivisionViewModel> Get()
        {
            return DivisionRepo.Get();
        }

        // GET api/<controller>/5
        public DivisionViewModel Get(int id)
        {
            return DivisionRepo.GetById(id);
        }

        // POST api/<controller>
        public Responses Post([FromBody]DivisionViewModel entity)
        {
            return DivisionRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody] DivisionViewModel entity)
        {
            entity.Id = id;
            //using (var db = new PayrollContext())
            //{
            //    Division division = db.Division.Where(o => o.Id == id)
            //        .FirstOrDefault();

            //    if (division != null)
            //    {
            //        entity
            //    }
            //}
                return DivisionRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return DivisionRepo.Delete(id);
        }
    }
}