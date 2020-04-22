using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    public class ServiceAppliancesController : Controller
    {
        private ApplicationDbContext _context;

        public ServiceAppliancesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: ServiceAppliances
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var applianceViewModel = new ServiceApplianceViewModel
            {
                ServiceAppliance = new ServiceAppliance(),
                Brands = _context.Brands.ToList(),
                DeviceTypes = _context.DeviceTypes.ToList()
            };

            return View("ServiceApplianceForm", applianceViewModel);
        }

        public ActionResult Edit(int id)
        {
            var applianceInDb = _context.ServiceAppliances.Find(id);
            
            if (applianceInDb == null)
                return HttpNotFound();

            var applianceViewModel = new ServiceApplianceViewModel
            {
                ServiceAppliance = applianceInDb,
                Brands = _context.Brands.ToList(),
                DeviceTypes = _context.DeviceTypes.ToList()
            };

            return View("ServiceApplianceForm", applianceViewModel);
        }

        public ActionResult Save(ServiceApplianceViewModel viewModel)
        {
            var appliance = viewModel.ServiceAppliance;

            if (!ModelState.IsValid)
            {
                var applianceViewModel = new ServiceApplianceViewModel
                {
                    ServiceAppliance = appliance,
                    Brands = _context.Brands.ToList(),
                    DeviceTypes = _context.DeviceTypes.ToList()
                };

                return View("ServiceApplianceForm", applianceViewModel);
            }
            if (appliance.Id == 0)
                _context.ServiceAppliances.Add(appliance);
            else
            {
                var applianceInDb = _context.ServiceAppliances.SingleOrDefault(a => a.Id == appliance.Id);
                applianceInDb.Model = appliance.Model;
                applianceInDb.BrandId = appliance.BrandId;
                applianceInDb.DevicetypeId = appliance.DevicetypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}