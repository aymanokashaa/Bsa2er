namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "countryofbirth", c => c.String());
         //   DropColumn("dbo.AspNetUsers", "nationality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "nationality", c => c.String());
           // DropColumn("dbo.AspNetUsers", "countryofbirth");
        }
    }
}
