using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class PartsController : ApiController
    {
        private ApplicationDbContext _context;

        public PartsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetParts(string query = null)
        {
            var partsQuery = _context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartCategory);

            if (!String.IsNullOrWhiteSpace(query))
                partsQuery = partsQuery.Where(p => p.Model.Contains(query));
                
            var partDtos  = partsQuery
                .ToList()
                .Select(Mapper.Map<Part, PartDto>);

            return Ok(partDtos);
        }

        /// <summary>
        /// Get parts that belong to service center
        /// </summary>
        /// <param name="id">service center id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetParts(int id)
        {
            var partDtos = _context.PartsInServiceCenters
                .Include(p => p.Part)
                .Include(p => p.Part.Brand)
                .Include(p => p.Part.PartCategory)
                .Where(p => p.ServiceCenterId == id)
                .ToList()
                .Select(p => Mapper.Map<Part, PartDto>(p.Part));

            return Ok(partDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeletePart(int id)
        {
            var partInDb = _context.Parts.Find(id);

            if (partInDb == null)
                return NotFound();

            _context.Parts.Remove(partInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
