using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

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
        public IHttpActionResult GetParts()
        {
            var partsDtos = _context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartCategory)
                .ToList()
                .Select(Mapper.Map<Part, PartDto>);

            return Ok(partsDtos);
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
