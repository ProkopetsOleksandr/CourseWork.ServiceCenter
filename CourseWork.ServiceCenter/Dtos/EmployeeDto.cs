using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public int EmployeePositionId { get; set; }

        public int ServiceCenterId { get; set; }

        public EmployeePositionDto EmployeePosition { get; set; }

        public ServiceCenterDto ServiceCenter { get; set; }
    }
}