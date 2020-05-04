using CourseWork.ServiceCenter.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.ViewModels
{
    public class RegisterPageViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}