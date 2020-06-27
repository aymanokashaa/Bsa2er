namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reseting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LectureFiles", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.LectureFiles", new[] { "Lecture_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.LectureFiles", "Lecture_Id");
            AddForeignKey("dbo.LectureFiles", "Lecture_Id", "dbo.Lectures", "Lecture_Id", cascadeDelete: true);
        }
    }
}
