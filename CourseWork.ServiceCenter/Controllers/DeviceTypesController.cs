using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
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
            return View();
        }


        public ActionResult New()
        {
            return View("DeviceTypeForm", new DeviceType());
        }

        public ActionResult Edit(int id)
        {
            var deviceTypeInDb = _context.DeviceTypes.Find(id);

            if (deviceTypeInDb == null)
                return HttpNotFound();

            return View("DeviceTypeForm", deviceTypeInDb);
        }

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