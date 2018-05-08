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
    public class AttendancesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<AttendanceViewModel> Get()
        {
            return AttendanceRepo.Get();
        }

        // GET api/<controller>/5
        public AttendanceViewModel Get(int id)
        {
            return AttendanceRepo.GetById(id);
        }

        public AttendanceViewModel Get(string badgeId)
        {
            return AttendanceRepo.GetByBadgeId(badgeId);
        }
        // POST api/<controller>
        public Responses Post([FromBody]AttendanceViewModel entity)
        {
           return AttendanceRepo.Update(entity);
        }

        // PUT api/<controller>/5
        public Responses Put(int id, [FromBody]AttendanceViewModel entity)
        {
            entity.Id = id;
            return AttendanceRepo.Update(entity);
        }

        // DELETE api/<controller>/5
        public Responses Delete(int id)
        {
            return AttendanceRepo.Delete(id);
        }
    }
}