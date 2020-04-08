using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWork.ServiceCenter;
using CourseWork.ServiceCenter.Models;

namespace CourseWork.ServiceCenter.Controllers
{
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
            return View(_context.ServiceTypes.ToList());
        }

        // GET: ServiceTypes/Create
        public ActionResult New()
        {
            return View("ServiceTypeForm", new ServiceType());
        }

        public ActionResult Edit(int id)
        {
            var serviceTypeInDb = _context.ServiceTypes.Find(id);

            if (serviceTypeInDb == null)
                return HttpNotFound();

            return View("ServiceTypeForm", serviceTypeInDb);
        }

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
