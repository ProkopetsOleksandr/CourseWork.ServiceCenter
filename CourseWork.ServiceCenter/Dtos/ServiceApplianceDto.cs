using CourseWork.ServiceCenter.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceApplianceDto
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