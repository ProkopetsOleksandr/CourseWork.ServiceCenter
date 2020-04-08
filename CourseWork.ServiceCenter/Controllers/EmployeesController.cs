using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var employeeFormViewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                EmployeePositions = _context.EmployeePositions.ToList(),
                ServiceCenters = _context.ServiceCenters.ToList()
            };

            return View("EmployeeForm", employeeFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employeeInDb == null)
                return HttpNotFound();

            var employeeFormViewModel = new EmployeeFormViewModel
            {
                Employee = employeeInDb,
                EmployeePositions = _context.EmployeePositions.ToList(),
                ServiceCenters = _context.ServiceCenters.ToList()
            };

            return View("EmployeeForm", employeeFormViewModel);
        }

        public ActionResult Save(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                var employeeFormViewModel = new EmployeeFormViewModel
                {
                    Employee = employee,
                    EmployeePositions = _context.EmployeePositions.ToList(),
                    ServiceCenters = _context.ServiceCenters.ToList()
                };

                return View("EmployeeForm", employeeFormViewModel);
            }

            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
            {
                var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.Address = employee.Address;
                employeeInDb.Phone = employee.Phone;
                employeeInDb.EmployeePositionId = employee.EmployeePositionId;
                employeeInDb.ServiceCenterId = employee.ServiceCenterId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}