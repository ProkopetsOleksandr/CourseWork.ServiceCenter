namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceAppliance")]
    public partial class ServiceAppliance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceAppliance()
        {
            Order = new HashSet<Order>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string model { get; set; }

        public int brandId { get; set; }

        public int devicetypeId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
