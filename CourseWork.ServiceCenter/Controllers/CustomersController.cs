using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{ 
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            ViewBag.Title = "Edit customer";

            return View("CustomerForm", customer);
        }

        public ActionResult New()
        {
            var customer = new Customer();
            return View("CustomerForm", customer);
        }

        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                TryUpdateModel(customerInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}