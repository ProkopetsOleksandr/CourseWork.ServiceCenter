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
    public class BrandsController : ApiController
    {

        private ApplicationDbContext _context;

        public BrandsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetBrands(string query = null)
        {
            var brandsQuery = _context.Brands.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                brandsQuery.Where(b => b.Title.Contains(query));

            var brandDtos = brandsQuery
                .ToList()
                .Select(Mapper.Map<Brand, BrandDto>);

            return Ok(brandDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteBrand(int id)
        {
            var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brandInDb == null)
                return NotFound();

            _context.Brands.Remove(brandInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
