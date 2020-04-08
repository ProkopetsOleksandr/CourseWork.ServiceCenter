using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceTypeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}