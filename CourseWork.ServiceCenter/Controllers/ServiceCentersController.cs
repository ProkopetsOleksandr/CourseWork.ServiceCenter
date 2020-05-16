using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models.Identity;
using CourseWork.ServiceCenter.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    public class ServiceCentersController : Controller
    {
        private ApplicationDbContext _context;
        public ServiceCentersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ServiceCenters
        public ActionResult Index()
        {
            if (User.IsInRole(Role.Admin))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult View(int id)
        {
            var centerInDb = _context.ServiceCenters
                .Include(c => c.City)
                .SingleOrDefault(c => c.Id == id);

            if (centerInDb == null)
                return HttpNotFound();

            return View(centerInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            var centerViewModel = new ServiceCenterViewModel
            {
                ServiceCenter = new Models.ServiceCenter(),
                Cities = _context.Cities.ToList()
            };

            return View("ServiceCenterForm", centerViewModel);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var centerInDb = _context.ServiceCenters.Find(id);
            
            if (centerInDb == null)
                return HttpNotFound();

            var centerViewModel = new ServiceCenterViewModel
            {
                ServiceCenter = centerInDb,
                Cities = _context.Cities.ToList()
            };

            return View("ServiceCenterForm", centerViewModel);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Save(ServiceCenterViewModel serviceCenterViewModel)
        {
            var serviceCenter = serviceCenterViewModel.ServiceCenter;

            if(!ModelState.IsValid)
            {
                var centerViewModel = new ServiceCenterViewModel
                {
                    ServiceCenter = serviceCenter,
                    Cities = _context.Cities.ToList()
                };

                return View("ServiceCenterForm", centerViewModel);
            }

            if (serviceCenter.Id == 0)
                _context.ServiceCenters.Add(serviceCenter);
            else
            {
                var serviceCenterInDb = _context.ServiceCenters.SingleOrDefault(c => c.Id == serviceCenter.Id);
                serviceCenterInDb.CenterNumber = serviceCenter.CenterNumber;
                serviceCenterInDb.CityId = serviceCenter.CityId;
                serviceCenterInDb.Address = serviceCenter.Address;
                serviceCenterInDb.Phone = serviceCenter.Phone;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}