using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }

        [Display(Name = "ʳ������")]
        public int Quantity { get; set; }

        [Display(Name = "���������� ����� ������")]
        public int PartInServiceCenterId { get; set; }

        [Display(Name = "�����")]
        public int OrderServiceId { get; set; }

        public OrderService OrderService { get; set; }

        public PartInServiceCenter PartInServiceCenter { get; set; }
    }
}
