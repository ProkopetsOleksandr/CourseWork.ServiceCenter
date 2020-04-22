using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class ServiceApplianceViewModel
    {
        public ServiceAppliance ServiceAppliance { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<DeviceType> DeviceTypes { get; set; }
    }
}