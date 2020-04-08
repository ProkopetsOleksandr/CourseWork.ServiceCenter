using CourseWork.ServiceCenter.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceCenterDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string CenterNumber { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public int CityId { get; set; }

        public virtual CityDto City { get; set; }
    }
}