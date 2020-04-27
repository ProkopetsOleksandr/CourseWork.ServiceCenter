using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class OrderServicesViewModel
    {
        public OrderService OrderService { get; set; }
        public OrderFulfillment OrderFulfillment { get; set; }
        public IEnumerable<ServiceDetails> ServiceDetails { get; set; }
    }
}