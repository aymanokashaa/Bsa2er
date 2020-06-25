namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soundlecture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lectures", "Lecture_SoundLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lectures", "Lecture_SoundLink");
        }
    }
}
