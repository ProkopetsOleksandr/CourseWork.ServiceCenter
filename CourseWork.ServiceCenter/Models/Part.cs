using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.ServiceCenter.Models
{
    public partial class Part
    {
        public int id { get; set; }

        [Required]
        [StringLength(300)]
        public string model { get; set; }

        public int warrantyPeriod { get; set; }

        public decimal price { get; set; }

        [Required]
        [StringLength(10)]
        public string partCode { get; set; }

        public int partCategoryId { get; set; }

        public int brandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual PartCategory PartCategory { get; set; }
    }
}
