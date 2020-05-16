using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Models
{
    [Table("OrderFulfillment")]
    public class OrderFulfillment
    {
        public int Id { get; set; }

        [Display(Name = "���� �������")]
        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Display(Name = "���� ����������")]
        [Column(TypeName = "date")]
        public DateTime? DateDone { get; set; }

        [Display(Name = "�����")]
        public int OrderServiceId { get; set; }

        [Display(Name = "�������")]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public OrderService OrderService { get; set; }
    }
}
