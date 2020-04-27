using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class ServiceCenterViewModel
    {
        public Models.ServiceCenter ServiceCenter { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}