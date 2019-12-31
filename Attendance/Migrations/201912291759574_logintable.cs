namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logintable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogInViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogInViewModels", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.LogInViewModels", new[] { "EmployeeId" });
            DropTable("dbo.LogInViewModels");
        }
    }
}
