using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "ϲ�")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "����� ��������")]
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
    }
}
