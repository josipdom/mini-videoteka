namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Film",
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
                .ForeignKey("dbo.Zanr", t => t.ZanrId, cascadeDelete: true)
                .Index(t => t.ZanrId);
            
            CreateTable(
                "dbo.Zanr",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Film", "ZanrId", "dbo.Zanr");
            DropIndex("dbo.Film", new[] { "ZanrId" });
            DropTable("dbo.Zanr");
            DropTable("dbo.Film");
        }
    }
}
