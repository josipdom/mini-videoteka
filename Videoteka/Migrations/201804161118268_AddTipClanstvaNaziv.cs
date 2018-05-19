namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipClanstvaNaziv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipClanstvas", "Naziv", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipClanstvas", "Naziv");
        }
    }
}
