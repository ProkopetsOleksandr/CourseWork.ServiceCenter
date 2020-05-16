using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceCenterBrand")]
    public class ServiceCenterBrand
    {
        public int Id { get; set; }

        [Display(Name = "Бренд")]
        public int BrandId { get; set; }

        [Display(Name = "Сервіс центр")]
        public int ServiceCenterId { get; set; }

        public Brand Brand { get; set; }

        public ServiceCenter ServiceCenter { get; set; }
    }
}
