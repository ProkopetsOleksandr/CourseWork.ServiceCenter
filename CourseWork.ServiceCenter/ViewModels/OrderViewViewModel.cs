using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class OrderViewViewModel
    {
        public Order Order { get; set; }
        public Models.ServiceCenter ServiceCenter { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
}