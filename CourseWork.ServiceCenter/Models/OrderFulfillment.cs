using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("OrderFulfillment")]
    public class OrderFulfillment
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDone { get; set; }

        public int OrderServiceId { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public OrderService OrderService { get; set; }
    }
}
