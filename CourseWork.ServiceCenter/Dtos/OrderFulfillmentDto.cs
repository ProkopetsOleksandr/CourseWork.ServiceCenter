using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Dtos
{
    public class OrderFulfillmentDto
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDone { get; set; }

        public int OrderServiceId { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; }

        public OrderServiceDto OrderService { get; set; }
    }
}