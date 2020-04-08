using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class EmployeePositionsController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeePositionsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetEmployeePositions()
        {
            var positionDtos = _context.EmployeePositions.ToList().Select(Mapper.Map<EmployeePosition, EmployeePositionDto>);
            return Ok(positionDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeletePosition(int id)
        {
            var positionInDb = _context.EmployeePositions.Find(id);

            if (positionInDb == null)
                return NotFound();

            _context.EmployeePositions.Remove(positionInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
