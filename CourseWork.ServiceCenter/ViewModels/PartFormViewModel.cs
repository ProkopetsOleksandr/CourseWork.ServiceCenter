using CourseWork.ServiceCenter.Models;
using System.Collections.Generic;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class PartFormViewModel
    {
        public Part Part { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<PartCategory> PartCategories { get; set; }
    }
}