using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("PartInServiceCenter")]
    public class PartInServiceCenter
    {
        public int Id { get; set; }

        [Display(Name = "ʳ������")]
        public int Quantity { get; set; }

        [Display(Name = "����� �����")]
        public int ServiceCenterId { get; set; }

        [Display(Name = "����������")]
        public int PartId { get; set; }

        public Part Part { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
