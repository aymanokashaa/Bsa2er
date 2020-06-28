namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "pathofimage", c => c.String());
           // DropColumn("dbo.AspNetUsers", "imagepath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "imagepath", c => c.String());
          //  DropColumn("dbo.AspNetUsers", "pathofimage");
        }
    }
}
