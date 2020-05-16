using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class PartsInServiceCenterController : ApiController
    {
        private ApplicationDbContext _context;
        public PartsInServiceCenterController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetPartsInServiceCenter(int id)
        {
            var parts = _context.PartsInServiceCenters
                .Include(p => p.Part)
                .Where(p => p.ServiceCenterId == id && p.Quantity > 0)
                .ToList()
                .Select(Mapper.Map<PartInServiceCenter, PartInServiceCenterDto>);

            return Ok(parts);
        }

        [Route("api/partsInServiceCenter/filter")]
        [HttpGet]
        public IHttpActionResult PartsFilter(int id, string query = null)
        {
            var partsQuery = _context.PartsInServiceCenters
                .Include(p => p.Part)
                .Where(p => p.ServiceCenterId == id && p.Quantity > 0)
                .AsQueryable();

            partsQuery = partsQuery.Where(p => p.Part.Model.Contains(query));


            var parts = partsQuery
                .ToList()
                .Select(p => Mapper.Map<Part, PartDto>(p.Part));

            return Ok(parts);
        }

        [HttpPost]
        public IHttpActionResult AddPartToServiceCenter(PartInServiceCenterViewModel viewModel)
        {
            var centerInDb = _context.ServiceCenters.Find(viewModel.ServiceCenterId);
            if (centerInDb == null)
                return NotFound();

            var partInDb = _context.Parts.Find(viewModel.PartId);
            if (partInDb == null)
                return NotFound();

            var partInServiceCenter = _context.PartsInServiceCenters
                .SingleOrDefault(p => p.PartId == viewModel.PartId && p.ServiceCenterId == viewModel.ServiceCenterId);
            if (partInServiceCenter == null)
                _context.PartsInServiceCenters.Add(
                    new PartInServiceCenter
                    {
                        PartId = viewModel.PartId,
                        ServiceCenterId = viewModel.ServiceCenterId,
                        Quantity = viewModel.Quantity
                    });
            else
                partInServiceCenter.Quantity += viewModel.Quantity;

            _context.SaveChanges();
            return Ok();
        }
    }
}
