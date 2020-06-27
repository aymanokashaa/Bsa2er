namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "fullname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "fullname");
            DropColumn("dbo.AspNetUsers", "gender");
        }
    }
}
