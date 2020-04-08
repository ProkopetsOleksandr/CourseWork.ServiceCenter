using CourseWork.ServiceCenter.Models;
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

        // GET: Brands
        public ActionResult Index()
        {
            var brands = _context.Brands.ToList();
            return View(brands);
        }

        public ActionResult New()
        {
            var newBrand = new Brand();
            return View("BrandForm", newBrand);
        }

        public ActionResult Edit(int id)
        {
            var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brandInDb == null)
                return HttpNotFound();

            return View("BrandForm", brandInDb);
        }

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