namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeloginmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Name", c => c.String());
        }
    }
}
