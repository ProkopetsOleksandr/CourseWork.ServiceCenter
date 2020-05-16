using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.ServiceCenter.Models.Identity
{
    public static class Role
    {
        public const string Admin = "admin";
        public const string Manager = "manager";
        public const string Master = "master";

        public static string For(params string[] roles)
        {
            return string.Join(",", roles);
        }
    }
}