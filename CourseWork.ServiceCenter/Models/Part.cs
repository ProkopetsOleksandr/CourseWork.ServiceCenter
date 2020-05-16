using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("Part")]
    public class Part
    {
        public int Id { get; set; }

        [Display(Name = "������")]
        [Required]
        [StringLength(300)]
        public string Model { get; set; }

        [Display(Name = "���������� �����")]
        public int WarrantyPeriod { get; set; }

        [Display(Name = "ֳ��")]
        public decimal Price { get; set; }

        [Display(Name = "����� ����������")]
        [Required]
        [StringLength(10)]
        public string PartCode { get; set; }

        [Display(Name = "��������")]
        public int PartCategoryId { get; set; }

        [Display(Name = "�����")]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public PartCategory PartCategory { get; set; }
    }
}
