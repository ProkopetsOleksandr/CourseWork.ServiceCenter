﻿using AutoMapper;
using CourseWork.ServiceCenter.Dtos;
using CourseWork.ServiceCenter.Models;
using System.Linq;
using System.Web.Http;

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
        public IHttpActionResult GetDeviceTypes()
        {
            var deviceTypeDtos = _context.DeviceTypes.ToList().Select(Mapper.Map<DeviceType, DeviceTypeDto>);
            return Ok(deviceTypeDtos);
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
