using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.Models
{
    [Table("ServiceCenter")]
    public class ServiceCenter
    {
        public int Id { get; set; }

        [Display(Name = "Адреса")]
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Display(Name = "Номер сервіс центру")]
        [Required]
        [StringLength(20)]
        public string CenterNumber { get; set; }

        [Display(Name = "Номер телефону")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Display(Name = "Місто")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
