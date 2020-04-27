using CourseWork.ServiceCenter.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
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
    }
}