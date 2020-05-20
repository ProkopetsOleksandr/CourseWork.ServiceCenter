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

        [Route("api/orders/getFinishedOrders/")]
        [HttpGet]
        public IHttpActionResult GetFinishedOrders(int id)
        {
            var finishedOrders = _context.OrderFulfillments
                .Include(f => f.OrderService)
                .Include(f => f.OrderService.Order.Employee)
                .Include(f => f.OrderService.Order.Customer)
                .Where(f => f.OrderService.Order.Employee.ServiceCenterId == id && f.OrderService.Order.OrderDone == null)
                .Select(f => new { id = f.Id, customer = f.OrderService.Order.Customer, orderId = f.OrderService.Order.Id, orderNumber = f.OrderService.Order.OrderNumber })
                .ToList();

            return Ok(finishedOrders);
        }

        [Route("api/orders/finishOrder/{id}")]
        [HttpGet]
        public IHttpActionResult FinishOrder(int id)
        {
            var fulfillmentInDb = _context.OrderFulfillments
                .Include(f => f.OrderService.Order)
                .SingleOrDefault(f => f.Id == id);
            if(fulfillmentInDb == null)
            {
                return NotFound();
            }

            var orderInDb = _context.Orders.Find(fulfillmentInDb.OrderService.Order.Id);
            orderInDb.OrderDone = System.DateTime.Now;
            _context.SaveChanges();
            return Ok();
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
