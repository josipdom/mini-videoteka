namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilm2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Naziv = c.String(nullable: false, maxLength: 255),
                    ZanrId = c.Byte(nullable: false),
                    DatumDodano = c.DateTime(nullable: false),
                    DatumIzlaska = c.DateTime(nullable: false),
                    BrojNaSkladistu = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zanrs", t => t.ZanrId, cascadeDelete: true)
                .Index(t => t.ZanrId);

            CreateTable(
                "dbo.Zanrs",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Naziv = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Films", "ZanrId", "dbo.Zanrs");
            DropIndex("dbo.Films", new[] { "ZanrId" });
            DropTable("dbo.Zanrs");
            DropTable("dbo.Films");
        }
    }
}
