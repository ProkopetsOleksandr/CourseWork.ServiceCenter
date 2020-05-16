using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    [OnlyAllowed(Roles = Role.Admin + "," + Role.Manager)]
    public class ServiceTypesController : Controller
    {
        private ApplicationDbContext _context;

        public ServiceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ServiceTypes
        public ActionResult Index()
        {
            if(User.IsInRole(Role.Admin))
                return View("List");

            return View("ReadOnlyList");
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            return View("ServiceTypeForm", new ServiceType());
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var serviceTypeInDb = _context.ServiceTypes.Find(id);

            if (serviceTypeInDb == null)
                return HttpNotFound();

            return View("ServiceTypeForm", serviceTypeInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", serviceType);
            }

            if (serviceType.Id == 0)
                _context.ServiceTypes.Add(serviceType);
            else
            {
                var serviceTypeInDb = _context.Employees.Find(serviceType.Id);
                TryValidateModel(serviceTypeInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "ServiceTypes");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
