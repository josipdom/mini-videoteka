namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToKupacNaziv : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kupacs", "Naziv", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kupacs", "Naziv", c => c.String());
        }
    }
}
