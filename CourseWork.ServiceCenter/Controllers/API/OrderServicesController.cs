using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Dtos;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class OrderServicesController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderServicesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IHttpActionResult GetOrderServices(int id)
        {
            var serviceDtos = _context.OrderServices
                .Include(s => s.ServiceType)
                .Where(s => s.OrderId == id)
                .ToList()
                .Select(Mapper.Map<OrderService, OrderServiceDto>);

            return Ok(serviceDtos);
        }
    }
}
