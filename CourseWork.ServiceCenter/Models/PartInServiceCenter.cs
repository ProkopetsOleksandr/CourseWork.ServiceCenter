namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartInServiceCenter")]
    public partial class PartInServiceCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartInServiceCenter()
        {
            ServiceDetails = new HashSet<ServiceDetails>();
        }

        public int id { get; set; }

        public int quantity { get; set; }

        public int serviceCenterId { get; set; }

        public int partId { get; set; }

        public virtual Part Part { get; set; }

        public virtual ServiceCenter ServiceCenter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceDetails> ServiceDetails { get; set; }
    }
}
