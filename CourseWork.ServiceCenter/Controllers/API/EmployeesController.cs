using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetEmployees(string query = null)
        {
            var employeesQuery = _context.Employees
                .Include(e => e.EmployeePosition)
                .Include(e => e.ServiceCenter);

            if (!String.IsNullOrWhiteSpace(query))
                employeesQuery = employeesQuery.Where(c => c.Name.Contains(query));

            var customerDtos = employeesQuery
                .ToList()
                .Select(Mapper.Map<Employee, EmployeeDto>);

            return Ok(customerDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employeeInDb == null)
                return NotFound();

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
