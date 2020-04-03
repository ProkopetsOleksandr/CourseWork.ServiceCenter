namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceDetails
    {
        public int id { get; set; }

        public int quantity { get; set; }

        public int partInServiceCenterId { get; set; }

        public int orderServiceId { get; set; }

        public virtual OrderService OrderService { get; set; }

        public virtual PartInServiceCenter PartInServiceCenter { get; set; }
    }
}
