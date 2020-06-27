namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "dateofbirth", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "dateofbirth");
        }
    }
}
