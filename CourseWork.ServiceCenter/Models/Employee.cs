using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "ϲ�")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "����� ��������")]
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Display(Name = "������")]
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Display(Name = "���� ����������")]
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Display(Name = "������")]
        public int EmployeePositionId { get; set; }

        [Display(Name = "����� �����")]
        public int ServiceCenterId { get; set; }

        public EmployeePosition EmployeePosition { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
