using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using CourseWork.ServiceCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CourseWork.ServiceCenter.Controllers
{
    [OnlyAllowed(Roles = Role.Admin + "," + Role.Manager)]
    public class CitiesController : Controller
    {
        private ApplicationDbContext _context;

        public CitiesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(Role.Admin))
                return View("List");

            return View("ReadOnlyList");
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            return View("CityForm", new City());
        }

        
        public ActionResult View(int id)
        {
            var cityInDb = _context.Cities.Find(id);

            if (cityInDb == null)
                return HttpNotFound();

            var cityViewModel = new CityFormViewModel
            {
                City = cityInDb,
                ServiceCenters = _context.ServiceCenters.Where(s => s.CityId == cityInDb.Id)
            };

            return View(cityViewModel);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var cityInDb = _context.Cities.Find(id);

            if (cityInDb == null)
                return HttpNotFound();

            return View("CityForm", cityInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Save(City city)
        {
            if (!ModelState.IsValid)
                return View("CityForm", city);

            if (city.Id == 0)
                _context.Cities.Add(city);
            else
            {
                var cityInDb = _context.Cities.SingleOrDefault(c => c.Id == city.Id);
                TryUpdateModel(cityInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Cities");
        }
    }
}