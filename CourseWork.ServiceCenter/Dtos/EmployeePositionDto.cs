using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Dtos
{
    public class EmployeePositionDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}