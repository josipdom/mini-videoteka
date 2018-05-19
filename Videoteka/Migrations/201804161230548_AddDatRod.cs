namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatRod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kupacs", "DatumRodenja", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kupacs", "DatumRodenja");
        }
    }
}
