using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class ServiceCenterDeviceTypesController : ApiController
    {
        private ApplicationDbContext _context;
        public ServiceCenterDeviceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetTypesInServiceCenter(int id)
        {
            var types = _context.ServiceCenterDeviceTypes
                .Include(t => t.DeviceType)
                .Where(p => p.ServiceCenterId == id)
                .ToList()
                .Select(Mapper.Map<ServiceCenterDeviceType, ServiceCenterDeviceTypeDto>);

            return Ok(types);
        }

        [HttpPost]
        public IHttpActionResult AddDeviceTypeToServiceCenter(ServiceCenterDeviceTypeViewModel viewModel)
        {
            var centerInDb = _context.ServiceCenters.Find(viewModel.ServiceCenterId);
            if (centerInDb == null)
                return NotFound();

            var deviceTypeInDb = _context.DeviceTypes.Find(viewModel.DeviceTypeId);
            if (deviceTypeInDb == null)
                return NotFound();


            var typesInServiceCenter = _context.ServiceCenterDeviceTypes
                .SingleOrDefault(t => t.DeviceTypeId == viewModel.DeviceTypeId && t.ServiceCenterId == viewModel.ServiceCenterId);
            if (typesInServiceCenter == null)
                _context.ServiceCenterDeviceTypes.Add(
                    new ServiceCenterDeviceType
                    {
                        ServiceCenterId = viewModel.ServiceCenterId,
                        DeviceTypeId = viewModel.DeviceTypeId,
                    });

            _context.SaveChanges();
            return Ok();
        }
    }
}
