using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceType")]
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "�����")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "ֳ��")]
        public decimal Price { get; set; }
    }
}
