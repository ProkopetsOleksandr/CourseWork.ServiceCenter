using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "����� ����������")]
        [Required]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Display(Name = "���� ����������")]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "ʳ����� ����")]
        public decimal? TotalPrice { get; set; }

        [Display(Name = "����")]
        [StringLength(300)]
        public string Description { get; set; }

        [Display(Name = "���� ����������")]
        [Column(TypeName = "date")]
        public DateTime? OrderDone { get; set; }

        [Display(Name = "��������")]
        public int EmployeeId { get; set; }

        [Display(Name = "�볺��")]
        public int CustomerId { get; set; }

        [Display(Name = "��������� �������")]
        public int ServiceApplianceId { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ServiceAppliance ServiceAppliance { get; set; }
    }
}
