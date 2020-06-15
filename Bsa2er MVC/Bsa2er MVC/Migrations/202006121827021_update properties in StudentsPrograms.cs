namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepropertiesinStudentsPrograms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentsPrograms", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentsPrograms", "EndDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentsPrograms", "EndDateTime");
            DropColumn("dbo.StudentsPrograms", "StartDateTime");
        }
    }
}
