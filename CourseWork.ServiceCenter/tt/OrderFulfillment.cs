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
    
    public partial class OrderFulfillment
    {
        public int id { get; set; }
        public System.DateTime dateStart { get; set; }
        public Nullable<System.DateTime> dateDone { get; set; }
        public int orderServiceId { get; set; }
        public int employeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual OrderService OrderService { get; set; }
    }
}