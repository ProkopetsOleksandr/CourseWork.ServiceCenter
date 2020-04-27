using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class PartInServiceCenterViewModel
    {
        public int ServiceCenterId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}