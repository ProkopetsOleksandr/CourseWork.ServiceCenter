using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Dtos;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServiceAppliancesController : ApiController
    {
        private ApplicationDbContext _context;

        public ServiceAppliancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAppliances()
        {
            var applianceDtos = _context.ServiceAppliances
                .Include(a => a.Brand)
                .Include(a => a.DeviceType)
                .ToList()
                .Select(Mapper.Map<ServiceAppliance, ServiceApplianceDto>);

            return Ok(applianceDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAppliance(int id)
        {
            var applianceInDb = _context.ServiceAppliances.Find(id);

            if (applianceInDb == null)
                return NotFound();

            _context.ServiceAppliances.Remove(applianceInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
