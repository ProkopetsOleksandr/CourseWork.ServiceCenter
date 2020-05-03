namespace CourseWork.ServiceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PupulateRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'20cf894d-963e-4f15-8be2-bbad3fc7c82c', N'admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'45df215f-242f-4d64-2fa9-aafs3da2s12a', N'manager')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'91da562a-512a-1s22-1gk5-uufj9gv8z69x', N'master')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
