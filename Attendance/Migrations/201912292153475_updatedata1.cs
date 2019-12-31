namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedata1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LogInViewModels", newName: "Logins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Logins", newName: "LogInViewModels");
        }
    }
}
