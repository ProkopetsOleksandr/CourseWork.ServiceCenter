using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CourseWork.ServiceCenter;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServiceTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public ServiceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetServiceTypes(string query = null)
        {
            var serviceTypesQuery = _context.ServiceTypes.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                serviceTypesQuery.Where(s => s.Name.Contains(query));

            var serviceTypeDtos = serviceTypesQuery
                .ToList()
                .Select(Mapper.Map<ServiceType, ServiceTypeDto>);

            return Ok(serviceTypeDtos);
        }


        [HttpDelete]
        public IHttpActionResult DeleteServiceType(int id)
        {
            ServiceType serviceTypeInDb = _context.ServiceTypes.Find(id);
            if (serviceTypeInDb == null)
            {
                return NotFound();
            }

            _context.ServiceTypes.Remove(serviceTypeInDb);
            _context.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeExists(int id)
        {
            return _context.ServiceTypes.Count(e => e.Id == id) > 0;
        }
    }
}