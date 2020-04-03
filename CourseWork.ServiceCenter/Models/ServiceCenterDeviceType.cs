namespace CourseWork.ServiceCenter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCenterDeviceType")]
    public partial class ServiceCenterDeviceType
    {
        public int id { get; set; }

        public int serviceCenterId { get; set; }

        public int deviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        public virtual ServiceCenter ServiceCenter { get; set; }
    }
}
