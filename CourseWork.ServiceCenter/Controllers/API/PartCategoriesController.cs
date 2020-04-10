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
    public class PartCategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public PartCategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categoriesDtos = _context.PartCategories
                .ToList()
                .Select(Mapper.Map<PartCategory, PartCategoryDto>);

            return Ok(categoriesDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = _context.PartCategories.SingleOrDefault(c => c.Id == id);

            if (categoryInDb == null)
                return NotFound();

            _context.PartCategories.Remove(categoryInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
