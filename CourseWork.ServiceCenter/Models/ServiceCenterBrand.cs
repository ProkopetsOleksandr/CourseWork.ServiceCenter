using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceCenterBrand")]
    public class ServiceCenterBrand
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int ServiceCenterId { get; set; }

        public Brand Brand { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
