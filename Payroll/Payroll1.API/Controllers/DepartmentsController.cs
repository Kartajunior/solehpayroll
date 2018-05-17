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
    public class DepartmentsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<DepartmentViewModel> Get()
        {
            return DepartmentRepo.Get();
        }

        // GET api/<controller>/5
        public DepartmentViewModel Get(int id)
        {
            return DepartmentRepo.GetById(id);
        }

        [HttpGet]
        [Route("~/api/departments/division/{DivId}")]
        public IEnumerable<DepartmentViewModel> GetByDiv(int DivId)
        {
            return DepartmentRepo.GetByDivId(DivId);
        }

        // POST api/<controller>
        public Responses Post([FromBody]DepartmentViewModel entity)
        {
            return DepartmentRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]DepartmentViewModel entity)
        {
            entity.Id = id;
            return DepartmentRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return DepartmentRepo.Delete(id);
        }
    }
}