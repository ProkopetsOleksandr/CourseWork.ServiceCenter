using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Номер замовлення")]
        [Required]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Display(Name = "Дата замовлення")]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Кінцева ціна")]
        public decimal? TotalPrice { get; set; }

        [Display(Name = "Опис")]
        [StringLength(300)]
        public string Description { get; set; }

        [Display(Name = "Дата завершення")]
        [Column(TypeName = "date")]
        public DateTime? OrderDone { get; set; }

        [Display(Name = "Менеджер")]
        public int EmployeeId { get; set; }

        [Display(Name = "Клієнт")]
        public int CustomerId { get; set; }

        [Display(Name = "Побутовий пристрій")]
        public int ServiceApplianceId { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ServiceAppliance ServiceAppliance { get; set; }
    }
}
