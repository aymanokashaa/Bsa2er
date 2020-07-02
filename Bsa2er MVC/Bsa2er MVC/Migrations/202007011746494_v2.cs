namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropPrimaryKey("dbo.Programs");
            AddColumn("dbo.Programs", "ProgramId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Programs", "ProgramId");
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "ProgramId", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "ProgramId", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "ProgramId", cascadeDelete: true);
            DropColumn("dbo.Programs", "Program_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "Program_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropPrimaryKey("dbo.Programs");
            DropColumn("dbo.Programs", "ProgramId");
            AddPrimaryKey("dbo.Programs", "Program_Id");
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
        }
    }
}
