namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2214210e-96fd-4105-af96-9f93f0510bcd', N'guest@vidly.com', 0, N'AFWCKAdPw627hXz+Ra36U1ZtT3N4uByrwQ/Sn6MBV1fss9+Hjz20CqI8FkFmq/H5fA==', N'81e92ebf-70b9-40bf-901b-3b598350f7d7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com');
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'325e3d95-b5e1-4009-a6df-796b9af5874d', N'adminnew@vidly.com', 0, N'AEr34eZaBksxWjEAaSDqsQrQTaTsqSB9QMffqqC2tCgPnGZyx0ZCI7Mrvm7yTj4i9A==', N'bddb0301-e3d9-4f24-9aad-dbb21693af15', NULL, 0, 0, NULL, 1, 0, N'adminnew@vidly.com');

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf00b655-f55a-4771-9666-dd4ff9d569d6', N'CanManageMovie');

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'325e3d95-b5e1-4009-a6df-796b9af5874d',N'bf00b655-f55a-4771-9666-dd4ff9d569d6');
");
        }
        
        public override void Down()
        {
        }
    }
}
