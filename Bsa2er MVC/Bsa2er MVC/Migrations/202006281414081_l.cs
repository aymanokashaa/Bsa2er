namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "birthcountry", c => c.String());
          //  DropColumn("dbo.AspNetUsers", "countryofbirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "countryofbirth", c => c.String());
            //DropColumn("dbo.AspNetUsers", "birthcountry");
        }
    }
}
