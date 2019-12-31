namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "joiningDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "joiningDate");
            DropColumn("dbo.Employees", "BirthDate");
            DropColumn("dbo.Employees", "salary");
        }
    }
}
