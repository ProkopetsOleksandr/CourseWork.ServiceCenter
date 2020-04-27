namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceCenterDeviceTypeDto
    {
        public int Id { get; set; }

        public int ServiceCenterId { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceTypeDto DeviceType { get; set; }

        public ServiceCenterDto ServiceCenter { get; set; }
    }
}