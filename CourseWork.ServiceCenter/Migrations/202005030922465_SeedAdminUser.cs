namespace CourseWork.ServiceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3d275acf-dded-4568-bb4e-7f62c88c2b9f', N'admin@service.com', 0, N'ALGAY8YAOfTWEE0r+zPTytVqyG3pl+MhwlK8WWlFpSEO8YUVuPeazXvYk+LEJqsJ/w==', N'966bbbc5-927b-414b-9f5e-2c1e09831417', NULL, 0, 0, NULL, 1, 0, N'admin@service.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'20cf894d-963e-4f15-8be2-bbad3fc7c82c', N'admin')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d275acf-dded-4568-bb4e-7f62c88c2b9f', N'20cf894d-963e-4f15-8be2-bbad3fc7c82c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
