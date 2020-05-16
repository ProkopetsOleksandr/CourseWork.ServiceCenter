using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            var orderDtos = _context.Orders
                .Include(o => o.ServiceAppliance)
                .Include(o => o.Employee)
                .Include(o => o.Customer)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);

            return Ok(orderDtos);
        }

        [HttpGet]
        public IHttpActionResult GetOrders(int id)
        {
            var orderDtos = _context.Orders
                .Include(o => o.ServiceAppliance)
                .Include(o => o.Employee)
                .Include(o => o.Customer)
                .Where(o => o.Employee.ServiceCenterId == id)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);

            return Ok(orderDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var orderInDb = _context.Orders.Find(id);

            if (orderInDb == null)
                return NotFound();

            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
