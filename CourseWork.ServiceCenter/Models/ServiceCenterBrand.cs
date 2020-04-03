namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCenterBrand")]
    public partial class ServiceCenterBrand
    {
        public int id { get; set; }

        public int brandId { get; set; }

        public int serviceCenterId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ServiceCenter ServiceCenter { get; set; }
    }
}
