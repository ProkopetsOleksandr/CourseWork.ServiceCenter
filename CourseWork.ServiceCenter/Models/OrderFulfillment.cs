namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderFulfillment")]
    public partial class OrderFulfillment
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDone { get; set; }

        public int orderServiceId { get; set; }

        public int employeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual OrderService OrderService { get; set; }
    }
}
