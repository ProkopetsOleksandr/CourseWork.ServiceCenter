using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("PartInServiceCenter")]
    public class PartInServiceCenter
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ServiceCenterId { get; set; }

        public int PartId { get; set; }

        public Part Part { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
