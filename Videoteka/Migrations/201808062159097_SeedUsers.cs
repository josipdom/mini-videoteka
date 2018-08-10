namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02eb36bc-90b5-4236-8cef-3958cc41e36a', N'test1@testaplikacija.test', 0, N'ADqxOJOQp2mjulAe6hWtNWTAqHPScNvFovcjIEzPALHaLDSVVTcyKOcPDl3Yu9Q5/g==', N'dca6d089-1c2f-4447-8d06-05fe775b0841', NULL, 0, 0, NULL, 1, 0, N'test1@testaplikacija.test')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d704bf2-1472-4ef6-80e2-9e07d4d6fe5c', N'admin@videoteka.hr', 0, N'AOj8eTJrWJE/NV+bEvBrz5QCh56K1laow/P1yW3jYC/zEW/ZzkLWEW+pGLrhObDqMw==', N'53a0f7ff-b954-425a-8bee-a1673c4e7aef', NULL, 0, 0, NULL, 1, 0, N'admin@videoteka.hr')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2a1d8936-a274-4f5e-b816-ae129b740216', N'UpravljanjeFilmovima')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d704bf2-1472-4ef6-80e2-9e07d4d6fe5c', N'2a1d8936-a274-4f5e-b816-ae129b740216')

");
        }
        
        public override void Down()
        {
        }
    }
}
