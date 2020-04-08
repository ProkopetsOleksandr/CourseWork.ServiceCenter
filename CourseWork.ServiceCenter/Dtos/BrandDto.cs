using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
    }
}