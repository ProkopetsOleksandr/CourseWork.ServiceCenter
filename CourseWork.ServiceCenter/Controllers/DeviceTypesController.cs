using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    [OnlyAllowed(Roles = Role.Admin + "," + Role.Manager)]
    public class DeviceTypesController : Controller
    {
        private ApplicationDbContext _context;

        public DeviceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DeviceTypes
        public ActionResult Index()
        {
            if (User.IsInRole(Role.Admin))
                return View("List");

            return View("ReadOnlyList");
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            return View("DeviceTypeForm", new DeviceType());
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var deviceTypeInDb = _context.DeviceTypes.Find(id);

            if (deviceTypeInDb == null)
                return HttpNotFound();

            return View("DeviceTypeForm", deviceTypeInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Save(DeviceType deviceType)
        {
            if (!ModelState.IsValid)
                return View("DeviceTypeForm", deviceType);

            if (deviceType.Id == 0)
                _context.DeviceTypes.Add(deviceType);
            else
            {
                var deviceTypeInDb = _context.DeviceTypes.SingleOrDefault(p => p.Id == deviceType.Id);
                TryUpdateModel(deviceTypeInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}