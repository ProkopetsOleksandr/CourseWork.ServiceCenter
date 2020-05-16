using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class NewOrderServicesController : ApiController
    {
        private ApplicationDbContext _context;
        public NewOrderServicesController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Get new order services (unset)
        /// </summary>
        /// <param name="id">service center id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetNewServices(int id)
        {
            var services = _context.NewOrderServices.Where(s => s.ServiceCenterId == id);
            return Ok(services);
        }
    }
}
