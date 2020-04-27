using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{

    [Table("ServiceCenterDeviceType")]
    public class ServiceCenterDeviceType
    {
        public int Id { get; set; }

        public int ServiceCenterId { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
