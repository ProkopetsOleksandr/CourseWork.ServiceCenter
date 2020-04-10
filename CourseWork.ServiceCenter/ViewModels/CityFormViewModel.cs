using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class CityFormViewModel
    {
        public City City { get; set; }
        public IEnumerable<Models.ServiceCenter> ServiceCenters { get; set; }
    }
}