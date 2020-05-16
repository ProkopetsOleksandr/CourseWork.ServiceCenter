using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class OrderFulfillmentViewModel
    {
        [Display(Name = "Майстер")]
        public OrderFulfillment OrderFulfillment { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}