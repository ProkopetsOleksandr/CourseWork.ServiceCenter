using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class JobsLoadController : ApiController
    {
        private ApplicationDbContext _context;

        public JobsLoadController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetProductivity(int id)
        {
            var prod = _context.EmployeeLoad.Where(p => p.ServiceCenterId == id);

            return Ok(prod);
        }
    }
}
