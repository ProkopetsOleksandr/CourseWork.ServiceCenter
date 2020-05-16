using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceType")]
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
    }
}
