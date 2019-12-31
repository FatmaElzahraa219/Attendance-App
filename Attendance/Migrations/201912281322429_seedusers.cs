namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10693fbb-f3fd-4fc2-924f-437be55dbd84', N'admin@attendance.com', 0, N'ACT0hCwkUHC/VtUsE918MYBwcubvJphfe6kK1HZxR2GKWe1Vid3SELIInlf8H0li2g==', N'a6ce3860-823e-4834-9d41-820dfae33dd6', NULL, 0, 0, NULL, 1, 0, N'admin@attendance.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90027b5b-582f-419b-84ee-7b0fffb3e62d', N'Employee@domain.com', 0, N'AKf3wVeF6hBKarORL8rbBycMSchTAaFzqya/sPYcanbXuvAvSsyf/3aBY6yJkP6W1g==', N'ce6516f4-94e3-4323-874c-57e05fe4169c', NULL, 0, 0, NULL, 1, 0, N'Employee@domain.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5bc32cdf-b3e2-4dc5-8967-c1bcddf7d64a', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10693fbb-f3fd-4fc2-924f-437be55dbd84', N'5bc32cdf-b3e2-4dc5-8967-c1bcddf7d64a')

");
        }
        
        public override void Down()
        {
        }
    }
}
