using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

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
                brandsQuery = brandsQuery.Where(b => b.Title.Contains(query));

            var brandDtos = brandsQuery
                .ToList()
                .Select(Mapper.Map<Brand, BrandDto>);

            return Ok(brandDtos);
        }

        [HttpGet]
        public IHttpActionResult GetBrandsInServiceCenter(int id)
        {
            var brandsInServiceCenter = _context.ServiceCenterBrands
                .Include(b => b.Brand)
                .Where(c => c.ServiceCenterId == id)
                .Select(b => new { Title = b.Brand.Title })
                .ToList();

            return Ok(brandsInServiceCenter);
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
