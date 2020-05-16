using CourseWork.ServiceCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class OrdersFulfillmentController : Controller
    {
        private ApplicationDbContext _context;
        public OrdersFulfillmentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: OrderFulfillments
        public ActionResult Edit(int id)
        {
            var fulfillmentInDb = _context.OrderFulfillments.Find(id);
            if (fulfillmentInDb == null)
                return HttpNotFound();


            var masterId = 2;
            var serviceCenterId = int.Parse(Session["serviceCenterId"].ToString());

            var viewModel = new OrderFulfillmentViewModel
            {
                OrderFulfillment = fulfillmentInDb,
                Employees = _context.Employees.Where(e => e.ServiceCenterId == serviceCenterId && e.EmployeePositionId == masterId)
            };


            return View(viewModel);
        }

        public ActionResult Save(OrderFulfillmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var masterId = 2;
                var serviceCenterId = int.Parse(Session["serviceCenterId"].ToString());
                var newViewModel = new OrderFulfillmentViewModel
                {
                    OrderFulfillment = viewModel.OrderFulfillment,
                    Employees = _context.Employees.Where(e => e.ServiceCenterId == serviceCenterId && e.EmployeePositionId == masterId)
                };
                return View("Edit", newViewModel);
            }

            var orderFulfillmentInDb = _context.OrderFulfillments.Find(viewModel.OrderFulfillment.Id);
            orderFulfillmentInDb.EmployeeId = viewModel.OrderFulfillment.EmployeeId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}