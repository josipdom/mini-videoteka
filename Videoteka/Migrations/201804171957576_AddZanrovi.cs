namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZanrovi : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Zanrs (Id, Naziv) VALUES (1, 'Akcija')");
            Sql("INSERT INTO Zanrs (Id, Naziv) VALUES (2, 'Triler')");
            Sql("INSERT INTO Zanrs (Id, Naziv) VALUES (3, 'Obiteljski')");
            Sql("INSERT INTO Zanrs (Id, Naziv) VALUES (4, 'Romantika')");
            Sql("INSERT INTO Zanrs (Id, Naziv) VALUES (5, 'Komedija')");
        }
        
        public override void Down()
        {
        }
    }
}
