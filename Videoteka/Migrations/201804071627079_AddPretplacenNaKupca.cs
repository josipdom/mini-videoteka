namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPretplacenNaKupca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kupacs", "PretplacenNaNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kupacs", "PretplacenNaNewsletter");
        }
    }
}
