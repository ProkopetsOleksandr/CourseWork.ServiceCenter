namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCenter")]
    public partial class ServiceCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCenter()
        {
            Employee = new HashSet<Employee>();
            PartInServiceCenter = new HashSet<PartInServiceCenter>();
            ServiceCenterBrand = new HashSet<ServiceCenterBrand>();
            ServiceCenterDeviceType = new HashSet<ServiceCenterDeviceType>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string address { get; set; }

        [Required]
        [StringLength(20)]
        public string centerNumber { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        public int cityId { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartInServiceCenter> PartInServiceCenter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCenterBrand> ServiceCenterBrand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCenterDeviceType> ServiceCenterDeviceType { get; set; }
    }
}
