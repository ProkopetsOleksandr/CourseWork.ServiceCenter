using CourseWork.ServiceCenter.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public decimal? TotalPrice { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDone { get; set; }

        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }

        public int ServiceApplianceId { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ServiceAppliance ServiceAppliance { get; set; }
    }
}