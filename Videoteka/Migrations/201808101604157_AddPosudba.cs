namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosudba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posudbe",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DatumNajma = c.DateTime(nullable: false),
                    DatumPovratka = c.DateTime(),
                    Kupac_Id = c.Int(nullable: false),
                    Film_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kupacs", t => t.Kupac_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Kupac_Id)
                .Index(t => t.Film_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posudbe", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Posudbe", "Kupac_Id", "dbo.Kupacs");
            DropIndex("dbo.Posudbe", new[] { "Film_Id" });
            DropIndex("dbo.Posudbe", new[] { "Kupac_Id" });
            DropTable("dbo.Posudbe");
        }
    }
}
