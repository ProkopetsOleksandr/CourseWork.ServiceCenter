﻿using CourseWork.ServiceCenter.DatabaseViews;
using CourseWork.ServiceCenter.Models;
using CourseWork.ServiceCenter.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CourseWork.ServiceCenter
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Models.ServiceCenter> ServiceCenters { get; set; }
        public DbSet<ServiceCenterBrand> ServiceCenterBrands { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ServiceAppliance> ServiceAppliances { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PartCategory> PartCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PartInServiceCenter> PartsInServiceCenters { get; set; }
        public DbSet<ServiceCenterDeviceType> ServiceCenterDeviceTypes { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<OrderFulfillment> OrderFulfillments { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }



        /* VIEW */
        public DbSet<EmployeeLoad> EmployeeLoad { get; set; }
        public DbSet<NewOrderServices> NewOrderServices { get; set; }
        public DbSet<Services> Services { get; set; }

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