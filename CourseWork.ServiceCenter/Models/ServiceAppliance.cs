using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceAppliance")]
    public class ServiceAppliance
    {
        public int Id { get; set; }

        [Display(Name = "������")]
        [Required]
        [StringLength(200)]
        public string Model { get; set; }

        [Display(Name = "�����")]
        public int BrandId { get; set; }

        [Display(Name = "��� �������")]
        public int DevicetypeId { get; set; }

        public Brand Brand { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
