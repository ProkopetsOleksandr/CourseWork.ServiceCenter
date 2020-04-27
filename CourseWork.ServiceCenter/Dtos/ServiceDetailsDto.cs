namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceDetailsDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int PartInServiceCenterId { get; set; }

        public int OrderServiceId { get; set; }

        public OrderServiceDto OrderService { get; set; }

        public PartInServiceCenterDto PartInServiceCenter { get; set; }
    }
}