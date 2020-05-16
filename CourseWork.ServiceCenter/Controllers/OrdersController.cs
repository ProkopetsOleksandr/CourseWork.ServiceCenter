using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using CourseWork.ServiceCenter.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    [OnlyAllowed(Roles = Role.Admin + "," + Role.Manager)]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var orderInDb = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ServiceAppliance)
                .SingleOrDefault(o => o.Id == id);

            if (orderInDb == null)
                return HttpNotFound();

            var serviceCenter = _context.ServiceCenters
                .Include(c => c.City)
                .SingleOrDefault(c => c.Id == orderInDb.Employee.ServiceCenterId);

            var viewModel = new OrderViewViewModel
            {
                Order = orderInDb,
                ServiceCenter = serviceCenter
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new OrderViewModel
            {
                Appliances = _context.ServiceAppliances.ToList(),
                ServiceTypes = _context.ServiceTypes.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Save(OrderViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View("New", viewModel);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Phone == viewModel.Phone);
            if(customerInDb == null)
            {
                var newCustomer = new Customer { Name = viewModel.Name, Phone = viewModel.Phone };
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                customerInDb = _context.Customers.SingleOrDefault(c => c.Phone == viewModel.Phone);
            }

            var applianceInDb = _context.ServiceAppliances.Find(viewModel.ApplianceId);
            if (applianceInDb == null)
                return HttpNotFound();

            var serviceTypeInDb = _context.ServiceTypes.Find(viewModel.ServiceTypeId);
            if (serviceTypeInDb == null)
                return HttpNotFound();

            var order = new Order
            {
                CustomerId = customerInDb.Id,
                OrderDate = DateTime.Now,
                EmployeeId = int.Parse(Session["employeeId"].ToString()),
                Description = viewModel.Description,
                OrderNumber = new Random().Next(1000000, 9999999).ToString(),
                ServiceApplianceId = applianceInDb.Id
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            var orderInDb = _context.Orders.SingleOrDefault(o => o.OrderNumber == order.OrderNumber);
            var orderService = new OrderService
            {
                OrderId = orderInDb.Id,
                ServicetypeId = serviceTypeInDb.Id,
                TotalServicePrice = serviceTypeInDb.Price
            };
            
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

            return RedirectToAction("Index");
        }
    }
}