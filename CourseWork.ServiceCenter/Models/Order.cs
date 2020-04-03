namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderService = new HashSet<OrderService>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string orderNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime orderDate { get; set; }

        public decimal? totalPrice { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? orderDone { get; set; }

        public int employeeId { get; set; }

        public int customerId { get; set; }

        public int serviceApplianceId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ServiceAppliance ServiceAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderService> OrderService { get; set; }
    }
}
