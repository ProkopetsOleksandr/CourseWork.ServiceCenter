using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("OrderService")]
    public class OrderService
    {
        public int Id { get; set; }

        public decimal? TotalServicePrice { get; set; }

        public int OrderId { get; set; }

        public int ServicetypeId { get; set; }

        public Order Order { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
