using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.Dtos
{
    public class OrderServiceDto
    {
        public int Id { get; set; }

        public decimal? TotalServicePrice { get; set; }

        public int OrderId { get; set; }

        public int ServicetypeId { get; set; }

        public OrderDto Order { get; set; }
        public ServiceTypeDto ServiceType { get; set; }
    }
}