using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using CourseWork.ServiceCenter.Attributes;
using CourseWork.ServiceCenter.Models.Identity;

namespace CourseWork.ServiceCenter.Controllers
{
    public class PartsController : Controller
    {
        private ApplicationDbContext _context;

        public PartsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Part
        public ActionResult Index()
        {
            if (User.IsInRole(Role.Admin))
                return View("List");
            
            return View("ReadOnlyList");
        }

        public ActionResult View(int id)
        {
            var partInDb = _context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartCategory)
                .SingleOrDefault(p => p.Id == id);

            return View(partInDb);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult New()
        {
            var partViewModel = new PartFormViewModel
            {
                Part = new Part(),
                Brands = _context.Brands.ToList(),
                PartCategories = _context.PartCategories.ToList()
            };

            return View("PartForm", partViewModel);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            var partInDb = _context.Parts.Find(id);

            if (partInDb == null)
                return HttpNotFound();

            var partViewModel = new PartFormViewModel
            {
                Part = partInDb,
                Brands = _context.Brands.ToList(),
                PartCategories = _context.PartCategories.ToList()
            };

            return View("PartForm", partViewModel);
        }

        [OnlyAllowed(Roles = Role.Admin)]
        public ActionResult Save(Part part)
        {
            if(!ModelState.IsValid)
            {
                var partViewModel = new PartFormViewModel
                {
                    Part = part,
                    Brands = _context.Brands.ToList(),
                    PartCategories = _context.PartCategories.ToList()
                };

                return View("PartForm", partViewModel);
            }

            if (part.Id == 0)
                _context.Parts.Add(part);
            else
            {
                var partInDb = _context.Parts.SingleOrDefault(p => p.Id == part.Id);
                partInDb.Model = part.Model;
                partInDb.BrandId = part.BrandId;
                partInDb.PartCategoryId = part.PartCategoryId;
                partInDb.PartCode = part.PartCode;
                partInDb.Price = part.Price;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}