using System;
using System.Web.Mvc;
using System.Data.Entity;
using CourseWork.ServiceCenter.ViewModels;
using System.Linq;

namespace CourseWork.ServiceCenter.Controllers
{
    public class OrderServicesController : Controller
    {
        private ApplicationDbContext _context;
        public OrderServicesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: OrderServices
        public ActionResult View(int id)
        {
            var serviceInDb = _context.OrderServices
                .Include(s => s.ServiceType)
                .SingleOrDefault(s => s.Id == id);

            if (serviceInDb == null)
                return HttpNotFound();

            var fulfillment = _context.OrderFulfillments
                .Include(f => f.Employee)
                .SingleOrDefault(f => f.OrderServiceId == serviceInDb.Id);

            var serviceDetails = _context.ServiceDetails
                .Include(d => d.PartInServiceCenter.Part)
                .Where(d => d.OrderServiceId == serviceInDb.Id);


            var viewModel = new OrderServicesViewModel
            {
                OrderService = serviceInDb,
                OrderFulfillment = fulfillment,
                ServiceDetails = serviceDetails
            };


            return View(viewModel);
        }
    }
}