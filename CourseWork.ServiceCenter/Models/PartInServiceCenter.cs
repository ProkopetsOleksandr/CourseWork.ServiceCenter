using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("PartInServiceCenter")]
    public class PartInServiceCenter
    {
        public int Id { get; set; }

        [Display(Name = "Кількість")]
        public int Quantity { get; set; }

        [Display(Name = "Сервіс центр")]
        public int ServiceCenterId { get; set; }

        [Display(Name = "Запчастина")]
        public int PartId { get; set; }

        public Part Part { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
