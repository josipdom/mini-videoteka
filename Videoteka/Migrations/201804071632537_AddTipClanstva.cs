namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipClanstva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipClanstvas",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        PristojbaZaPrijavu = c.Short(nullable: false),
                        TrajanjeMjeseci = c.Byte(nullable: false),
                        Popust = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Kupacs", "TipClanstvaId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Kupacs", "TipClanstvaId");
            AddForeignKey("dbo.Kupacs", "TipClanstvaId", "dbo.TipClanstvas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kupacs", "TipClanstvaId", "dbo.TipClanstvas");
            DropIndex("dbo.Kupacs", new[] { "TipClanstvaId" });
            DropColumn("dbo.Kupacs", "TipClanstvaId");
            DropTable("dbo.TipClanstvas");
        }
    }
}
