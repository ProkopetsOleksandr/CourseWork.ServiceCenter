using AutoMapper;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.ViewModels;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServiceCenterBrandsController : ApiController
    {
        private ApplicationDbContext _context;
        public ServiceCenterBrandsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetBrandsInServiceCenter(int id)
        {
            var brands = _context.ServiceCenterBrands
                .Include(b => b.Brand)
                .Where(p => p.ServiceCenterId == id)
                .ToList()
                .Select(Mapper.Map<ServiceCenterBrand, ServiceCenterBrandDto>);

            return Ok(brands);
        }

        [HttpPost]
        public IHttpActionResult AddPartToServiceCenter(ServiceCenterBrandViewModel viewModel)
        {
            var centerInDb = _context.ServiceCenters.Find(viewModel.ServiceCenterId);
            if (centerInDb == null)
                return NotFound();

            var brandInDb = _context.Brands.Find(viewModel.BrandId);
            if (brandInDb == null)
                return NotFound();

            var brandInServiceCenter = _context.ServiceCenterBrands
                .SingleOrDefault(p => p.BrandId == viewModel.BrandId && p.ServiceCenterId == viewModel.ServiceCenterId);
            if (brandInServiceCenter == null)
                _context.ServiceCenterBrands.Add(
                    new ServiceCenterBrand
                    {
                        ServiceCenterId = viewModel.ServiceCenterId,
                        BrandId = viewModel.BrandId,
                    });

            _context.SaveChanges();
            return Ok();
        }
    }
}
