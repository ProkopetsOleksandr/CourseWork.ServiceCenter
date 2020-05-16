using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        [Route("api/customers/getcustomers")]
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        [Route("api/customers/getcustomersbyphone")]
        [HttpGet]
        public IHttpActionResult GetCustomersByPhone(string phone = null)
        {
            var customersQuery = _context.Customers.AsQueryable();

            if (!String.IsNullOrWhiteSpace(phone))
                customersQuery = customersQuery.Where(c => c.Phone.Contains(phone));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
