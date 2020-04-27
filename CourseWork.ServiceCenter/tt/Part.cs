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
    
    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            this.PartInServiceCenter = new HashSet<PartInServiceCenter>();
        }
    
        public int id { get; set; }
        public string model { get; set; }
        public int warrantyPeriod { get; set; }
        public decimal price { get; set; }
        public string partCode { get; set; }
        public int partCategoryId { get; set; }
        public int brandId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual PartCategory PartCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartInServiceCenter> PartInServiceCenter { get; set; }
    }
}
