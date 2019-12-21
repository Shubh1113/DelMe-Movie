namespace DelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e6a0d20f-86ca-4bc2-ba3f-947e0c06e83b', N'admin@DelMe.com', 0, N'ANEa3Zq0lc3vCfW6S3lZJfp7EdNm9tGk5v25rF4/VPxxNUja/pvRDZvTzJpRkroYKw==', N'f65a2ff2-e02d-4f41-815e-5ad253572514', NULL, 0, 0, NULL, 1, 0, N'admin@DelMe.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fd6fed65-c134-465a-834f-24d9305a880a', N'guest@DelMe.com', 0, N'AKhzaN+kSMhH5oVwwgZLvf42KWqo2u6wo9H8MuTznqru6OE/ZDV0+QgO/s0HSgVEaQ==', N'90bff15d-b738-41a9-993e-926f3ed8847f', NULL, 0, 0, NULL, 1, 0, N'guest@DelMe.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7329dc2e-fac6-40e6-a3eb-0513944a3f43', N'canManageMovie')
    
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e6a0d20f-86ca-4bc2-ba3f-947e0c06e83b', N'7329dc2e-fac6-40e6-a3eb-0513944a3f43')

              ");
        }
        
        public override void Down()
        {
        }
    }
}
