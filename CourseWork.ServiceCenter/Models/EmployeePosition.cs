using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("EmployeePosition")]
    public partial class EmployeePosition
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
