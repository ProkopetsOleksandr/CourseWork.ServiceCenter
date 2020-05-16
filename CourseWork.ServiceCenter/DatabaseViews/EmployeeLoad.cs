using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.DatabaseViews
{
    [Table("EmployeeLoad")]
    public class EmployeeLoad
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceCenterId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string Name { get; set; }

        public int? JobsLoad { get; set; }
    }
}
