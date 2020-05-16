using CourseWork.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class OrderViewModel
    {
     
        [Required]
        [Display(Name = "ПІБ")]
        public string Name { get; set; }

        [Display(Name = "Контактний номер телефону")]
        [Required]
        public string Phone { get; set; }

        // Order details
        [Display(Name = "Опис замовлення")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Побутова техніка")]
        public int ApplianceId { get; set; }

        [Required]
        [Display(Name = "Сервіс")]
        public int ServiceTypeId { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public IEnumerable<ServiceAppliance> Appliances { get; set; }
    }
}