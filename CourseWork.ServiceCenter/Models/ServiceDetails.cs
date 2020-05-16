using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }

        [Display(Name = "Кількість")]
        public int Quantity { get; set; }

        [Display(Name = "Запчастина сервіс центру")]
        public int PartInServiceCenterId { get; set; }

        [Display(Name = "Сервіс")]
        public int OrderServiceId { get; set; }

        public OrderService OrderService { get; set; }

        public PartInServiceCenter PartInServiceCenter { get; set; }
    }
}
