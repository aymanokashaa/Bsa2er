namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class programbody : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Program_Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Program_Body");
        }
    }
}
