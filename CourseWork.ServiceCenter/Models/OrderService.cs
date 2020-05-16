using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("OrderService")]
    public class OrderService
    {
        public int Id { get; set; }

        [Display(Name = "Кінцева ціна")]
        public decimal? TotalServicePrice { get; set; }

        [Display(Name = "Замовлення")]
        public int OrderId { get; set; }

        [Display(Name = "Тип сервісу")]
        public int ServicetypeId { get; set; }

        public Order Order { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
