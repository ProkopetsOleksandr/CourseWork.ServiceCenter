using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWork.ServiceCenter.DatabaseViews
{
    public class Services
    {
        public int? EmployeeId { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDone { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string Service { get; set; }
    }
}
