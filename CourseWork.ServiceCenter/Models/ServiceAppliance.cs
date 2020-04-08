using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceAppliance")]
    public class ServiceAppliance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Model { get; set; }

        public int BrandId { get; set; }

        public int DevicetypeId { get; set; }

        public Brand Brand { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
