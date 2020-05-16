using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{

    [Table("ServiceCenterDeviceType")]
    public class ServiceCenterDeviceType
    {
        public int Id { get; set; }

        [Display(Name = "Сервіс центр")]
        public int ServiceCenterId { get; set; }

        [Display(Name = "Тип пристрія")]
        public int DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
