using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
    }
}
