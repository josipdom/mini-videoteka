namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrojDostupnihFilmova : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "BrojDostupnih", c => c.Byte(nullable: false));
            Sql("UPDATE Films SET BrojDostupnih = BrojNaSkladistu");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "BrojDostupnih");
        }
    }
}
