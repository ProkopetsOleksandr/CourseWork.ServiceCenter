using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;

namespace CourseWork.ServiceCenter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(Role.Admin))
                return View();

            if (User.IsInRole(Role.Manager))
                return View("ManagerHome");

            return View("MasterHome");
        }
    }
}