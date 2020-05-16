using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class DeviceTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public DeviceTypesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDeviceTypes(string query = null)
        {
            var deviceTypeQuery = _context.DeviceTypes.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                deviceTypeQuery = deviceTypeQuery.Where(t => t.Title.Contains(query));

            var deviceTypeDtos =  deviceTypeQuery.ToList().Select(Mapper.Map<DeviceType, DeviceTypeDto>);
            return Ok(deviceTypeDtos);
        }

        [HttpGet]
        public IHttpActionResult GetDeviceTypesInServiceCenter(int id)
        {
            var deviceTypesInServiceCenter = _context.ServiceCenterDeviceTypes
                .Include(t => t.DeviceType)
                .Where(t => t.ServiceCenterId == id)
                .Select(t => new { Title = t.DeviceType.Title })
                .ToList();

            return Ok(deviceTypesInServiceCenter);
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeviceType(int id)
        {
            var deviceTypeInDb = _context.DeviceTypes.Find(id);

            if (deviceTypeInDb == null)
                return NotFound();

            _context.DeviceTypes.Remove(deviceTypeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
