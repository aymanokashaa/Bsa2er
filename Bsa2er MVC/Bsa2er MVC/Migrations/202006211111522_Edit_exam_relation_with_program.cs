namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_exam_relation_with_program : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Exams");
            AddColumn("dbo.Exams", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exams", "Program_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Exams", "Program_Id");
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropIndex("dbo.Exams", new[] { "Program_Id" });
            DropColumn("dbo.Exams", "Program_Id");
            DropColumn("dbo.Exams", "Active");
            AddForeignKey("dbo.Programs", "Program_Id", "dbo.Exams", "Exam_Id");
        }
    }
}
