namespace CourseWork.ServiceCenter.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int PartInServiceCenterId { get; set; }

        public int OrderServiceId { get; set; }

        public OrderService OrderService { get; set; }

        public PartInServiceCenter PartInServiceCenter { get; set; }
    }
}
