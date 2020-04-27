namespace CourseWork.ServiceCenter.Dtos
{
    public class PartInServiceCenterDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ServiceCenterId { get; set; }

        public int PartId { get; set; }

        public PartDto Part { get; set; }

        public ServiceCenterDto ServiceCenter { get; set; }
    }
}