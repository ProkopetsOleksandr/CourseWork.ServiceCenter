using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    public class BrandsController : Controller
    {
        private ApplicationDbContext _context;

        public BrandsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var brands = _context.Brands.ToList();

            if (User.IsInRole(Role.Admin))
                return View("List", brands);

            return View("ReadOnlyList", brands);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            var newBrand = new Brand();
            return View("BrandForm", newBrand);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brandInDb == null)
                return HttpNotFound();

            return View("BrandForm", brandInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Save(Brand brand)
        {
            if(!ModelState.IsValid)
            {
                return View("BrandForm", brand);
            }    

            if (brand.Id == 0)
                _context.Brands.Add(brand);
            else
            {
                var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == brand.Id);
                TryValidateModel(brandInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Brands");
        }
    }
}