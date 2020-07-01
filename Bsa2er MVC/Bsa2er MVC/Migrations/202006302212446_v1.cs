namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "dateofbirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "pathofimage", c => c.String());
            AddColumn("dbo.AspNetUsers", "gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "fullname", c => c.String());
            AddColumn("dbo.AspNetUsers", "birthcountry", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "birthcountry");
            DropColumn("dbo.AspNetUsers", "fullname");
            DropColumn("dbo.AspNetUsers", "gender");
            DropColumn("dbo.AspNetUsers", "pathofimage");
            DropColumn("dbo.AspNetUsers", "dateofbirth");
        }
    }
}
