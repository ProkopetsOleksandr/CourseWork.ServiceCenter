using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    public class PartCategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public PartCategoriesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: PartCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("PartCategoryForm", new PartCategory());
        }

        public ActionResult Edit(int id)
        {
            var categoryInDb = _context.PartCategories.Find(id);
            if (categoryInDb == null)
                return HttpNotFound();

            return View("PartCategoryForm", categoryInDb);
        }

        public ActionResult Save(PartCategory category)
        {
            if(!ModelState.IsValid)
            {
                return View("PartCategoryForm", category);
            }

            if (category.Id == 0)
                _context.PartCategories.Add(category);
            else
            {
                var categoryInDb = _context.PartCategories.SingleOrDefault(c => c.Id == category.Id);
                TryUpdateModel(categoryInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}