using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.DatabaseViews
{
    public partial class NewOrderServices
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceCenterId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderFulfillmentId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
