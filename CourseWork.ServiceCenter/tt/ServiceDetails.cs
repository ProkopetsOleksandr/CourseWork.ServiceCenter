//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork.ServiceCenter.tt
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceDetails
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int partInServiceCenterId { get; set; }
        public int orderServiceId { get; set; }
    
        public virtual OrderService OrderService { get; set; }
        public virtual PartInServiceCenter PartInServiceCenter { get; set; }
    }
}