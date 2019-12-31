namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesomethings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "delay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Attendances", "present", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "present", c => c.Int(nullable: false));
            DropColumn("dbo.Attendances", "delay");
        }
    }
}
