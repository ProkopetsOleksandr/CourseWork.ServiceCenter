using System.Web.Http;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServiceCentersController : ApiController
    {
        private ApplicationDbContext _context;

        public ServiceCentersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetServiceCenters()
        {
            var centerDtos = _context.ServiceCenters
                .Include(c => c.City)
                .ToList()
                .Select(Mapper.Map<Models.ServiceCenter, ServiceCenterDto>);

            return Ok(centerDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteServiceCenter(int id)
        {
            var serviceCenterInDb = _context.ServiceCenters.Find(id);

            if (serviceCenterInDb == null)
                return NotFound();

            _context.ServiceCenters.Remove(serviceCenterInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
