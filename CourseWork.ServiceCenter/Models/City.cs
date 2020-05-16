using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("City")]
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
    }
}
