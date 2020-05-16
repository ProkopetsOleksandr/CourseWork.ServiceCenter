namespace CourseWork.ServiceCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderFulfillmentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderFulfillment", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.OrderFulfillment", new[] { "EmployeeId" });
            AlterColumn("dbo.OrderFulfillment", "DateStart", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.OrderFulfillment", "EmployeeId", c => c.Int());
            CreateIndex("dbo.OrderFulfillment", "EmployeeId");
            AddForeignKey("dbo.OrderFulfillment", "EmployeeId", "dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderFulfillment", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.OrderFulfillment", new[] { "EmployeeId" });
            AlterColumn("dbo.OrderFulfillment", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderFulfillment", "DateStart", c => c.DateTime(nullable: false, storeType: "date"));
            CreateIndex("dbo.OrderFulfillment", "EmployeeId");
            AddForeignKey("dbo.OrderFulfillment", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
    }
}
