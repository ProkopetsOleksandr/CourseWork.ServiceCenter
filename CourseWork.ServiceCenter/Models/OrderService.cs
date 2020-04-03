namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderService")]
    public partial class OrderService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderService()
        {
            OrderFulfillment = new HashSet<OrderFulfillment>();
            ServiceDetails = new HashSet<ServiceDetails>();
        }

        public int id { get; set; }

        public decimal? totalServicePrice { get; set; }

        public int orderId { get; set; }

        public int servicetypeId { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFulfillment> OrderFulfillment { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceDetails> ServiceDetails { get; set; }
    }
}
