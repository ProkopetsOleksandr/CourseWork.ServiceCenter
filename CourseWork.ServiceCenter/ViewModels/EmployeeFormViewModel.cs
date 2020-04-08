using CourseWork.ServiceCenter.Models;
using System.Collections.Generic;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<EmployeePosition> EmployeePositions { get; set; }
        public IEnumerable<Models.ServiceCenter> ServiceCenters { get; set; }
        public Employee Employee { get; set; }
    }
}