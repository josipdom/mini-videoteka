namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradAdresaRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Grad", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Adresa", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Adresa");
            DropColumn("dbo.AspNetUsers", "Grad");
        }
    }
}
