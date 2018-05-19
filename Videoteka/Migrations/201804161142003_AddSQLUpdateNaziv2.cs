namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSQLUpdateNaziv2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE TipClanstvas SET Naziv = 'Direktno placanje' WHERE Id = 1");
            Sql("UPDATE TipClanstvas SET Naziv = 'Mjesecno' WHERE Id = 2");
            Sql("UPDATE TipClanstvas SET Naziv = 'Tromjesecno' WHERE Id = 3");
            Sql("UPDATE TipClanstvas SET Naziv = 'Godisnje' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
