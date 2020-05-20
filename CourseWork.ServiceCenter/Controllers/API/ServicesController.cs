using System.Web.Http;
using System.Linq;
using System.Data.Entity;
using CourseWork.ServiceCenter.ViewModels;
using CourseWork.ServiceCenter.Models;

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
            var services = _context.Services.Where(s => s.EmployeeId == id).ToList();
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

        [HttpPost]
        public IHttpActionResult AddServiceToOrder(ServiceViewModel viewModel)
        {
            var orderInDb = _context.Orders.Find(viewModel.OrderId);
            if(orderInDb == null)
            {
                return NotFound();
            }

            var serviceTypeInDb = _context.ServiceTypes.Find(viewModel.ServiceId);
            if(serviceTypeInDb == null)
            {
                return NotFound();
            }

            var orderService = new OrderService
            {
                OrderId = orderInDb.Id,
                ServicetypeId = serviceTypeInDb.Id,
                TotalServicePrice = serviceTypeInDb.Price
            };

            orderInDb.OrderDone = null;

            _context.OrderServices.Add(orderService);
            _context.SaveChanges();


            var orderServiceInDb = _context.OrderServices
                .SingleOrDefault(s => s.OrderId == orderInDb.Id && s.ServicetypeId == serviceTypeInDb.Id);


            var orderFulfillment = new OrderFulfillment
            {
                OrderServiceId = orderServiceInDb.Id,
                DateDone = null,
                DateStart = null,
                EmployeeId = null
            };

            _context.OrderFulfillments.Add(orderFulfillment);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/services/deleteService")]
        public IHttpActionResult DeleteServiceFromOrder(int id)
        {
            var orderService = _context.OrderServices.Find(id);
            if (orderService != null)
            {
                var fulfillment = _context.OrderFulfillments.SingleOrDefault(f => f.OrderServiceId == orderService.Id);
                _context.OrderFulfillments.Remove(fulfillment);
                _context.OrderServices.Remove(orderService);
                _context.SaveChanges();
            }



            return Ok();
        }

        /// <summary>
        /// Set fullfilment dateStart
        /// </summary>
        /// <param name="id">fulfillment id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/services/setFulFillmentInProcess")]
        public IHttpActionResult SetInProcess(int id)
        {
            var fulfillmentInDb = _context.OrderFulfillments.Find(id);
            if(fulfillmentInDb == null)
            {
                return NotFound();
            }

            fulfillmentInDb.DateStart = System.DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Set fullfilment dateEnd
        /// </summary>
        /// <param name="id">fulfillment id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/services/setFulfillmentFinished")]
        public IHttpActionResult SetFinished(int id)
        {
            var fulfillmentInDb = _context.OrderFulfillments.Find(id);
            if (fulfillmentInDb == null)
            {
                return NotFound();
            }

            fulfillmentInDb.DateDone = System.DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }
    }
}
