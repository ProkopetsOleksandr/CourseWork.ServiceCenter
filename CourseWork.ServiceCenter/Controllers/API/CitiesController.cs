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
    public class CitiesController : ApiController
    {
        private ApplicationDbContext _context;

        public CitiesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCities()
        {
            return Ok(_context.Cities.ToList().Select(Mapper.Map<City, CityDto>));
        }

        [HttpDelete]
        public IHttpActionResult DeleteCity(int id)
        {
            var cityInDb = _context.Cities.Find(id);

            if (cityInDb == null)
                return NotFound();

            _context.Cities.Remove(cityInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
