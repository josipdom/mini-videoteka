namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSQLUpdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE TipClanstvas SET Naziv = 'Direktno plaæanje' WHERE Id = 1");
            Sql("UPDATE TipClanstvas SET Naziv = 'Mjeseèno' WHERE Id = 2");
            Sql("UPDATE TipClanstvas SET Naziv = 'Tromjeseèno' WHERE Id = 3");
            Sql("UPDATE TipClanstvas SET Naziv = 'Godišnje' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}