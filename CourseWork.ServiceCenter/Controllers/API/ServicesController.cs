using System.Web.Http;
using System.Linq;
using System.Data.Entity;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServicesController : ApiController
    {
        private ApplicationDbContext _context;
        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/services/getServices")]
        [HttpGet]
        public IHttpActionResult GetMasterServices(int id)
        {
            var services = _context.Services.Where(s => s.EmployeeId == id);
            return Ok(services);
        }

        [Route("api/services/getParts")]
        [HttpGet]
        public IHttpActionResult GetServiceParts(int id)
        {
            var serviceParts = _context.ServiceDetails
                .Include(d => d.PartInServiceCenter.Part)
                .Where(d => d.OrderServiceId == id)
                .Select(p => new { p.PartInServiceCenter.Part.Model, p.PartInServiceCenter.Part.Price, p.Quantity });

            return Ok(serviceParts);
        }
    }
}
