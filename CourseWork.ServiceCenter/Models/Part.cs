using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Models
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Model { get; set; }

        public int WarrantyPeriod { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(10)]
        public string PartCode { get; set; }

        public int PartCategoryId { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public PartCategory PartCategory { get; set; }
    }
}
