using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "ПІБ")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Номер телефону")]
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Display(Name = "Адреса")]
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Display(Name = "Дата народження")]
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Посада")]
        public int EmployeePositionId { get; set; }

        [Display(Name = "Сервіс центр")]
        public int ServiceCenterId { get; set; }

        public EmployeePosition EmployeePosition { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
