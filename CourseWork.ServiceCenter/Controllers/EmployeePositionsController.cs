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
    [OnlyAllowed(Roles = Role.Admin)]
    public class EmployeePositionsController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeePositionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: EmployeePositions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("EmployeePositionForm", new EmployeePosition());
        }

        public ActionResult Edit(int id)
        {
            var positionInDb = _context.EmployeePositions.Find(id);

            if (positionInDb == null)
                return HttpNotFound();

            return View("EmployeePositionForm", positionInDb);
        }

        public ActionResult Save(EmployeePosition position)
        {
            if(!ModelState.IsValid)
                return View("EmployeePositionForm", position);

            if (position.Id == 0)
                _context.EmployeePositions.Add(position);
            else
            {
                var positionInDb = _context.EmployeePositions.SingleOrDefault(p => p.Id == position.Id);
                TryUpdateModel(positionInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}