namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ComingTime = c.DateTime(nullable: false),
                        DateOfDay = c.DateTime(nullable: false),
                        present = c.Int(nullable: false),
                        LeaveTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Attendances", new[] { "EmployeeID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Attendances");
        }
    }
}
