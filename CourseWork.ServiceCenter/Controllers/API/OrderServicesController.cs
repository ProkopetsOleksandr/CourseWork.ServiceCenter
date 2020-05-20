using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.ViewModels;

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

        [HttpPost]
        public IHttpActionResult AddPartToService(PartOrderServicesViewModel viewModel)
        {
            var partInServiceCenter = _context.PartsInServiceCenters
                .Include(p => p.Part)
                .SingleOrDefault(p => p.ServiceCenterId == viewModel.ServiceCenterId && p.PartId == viewModel.PartId);

            if (partInServiceCenter == null)
                return NotFound();

            if (partInServiceCenter.Quantity < viewModel.Quantity)
                return BadRequest("Недостатня кількість запчастин на складі.");

            var orderServiceInDb = _context.OrderServices.Find(viewModel.OrderServiceId);
            orderServiceInDb.TotalServicePrice += partInServiceCenter.Part.Price * viewModel.Quantity;


            var serviceDetails = new ServiceDetails()
            {
                OrderServiceId = viewModel.OrderServiceId,
                PartInServiceCenterId = partInServiceCenter.Id,
                Quantity = viewModel.Quantity
            };

            partInServiceCenter.Quantity -= viewModel.Quantity;

            _context.ServiceDetails.Add(serviceDetails);
            _context.SaveChanges();

            return Ok();
        }
    }
}
