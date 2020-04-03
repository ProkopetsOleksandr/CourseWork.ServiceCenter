using CourseWork.ServiceCenter.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CourseWork.ServiceCenter
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Part> Parts;


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}