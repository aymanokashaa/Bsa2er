namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletefilelec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LectureFiles", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.LectureFiles", new[] { "Lecture_Id" });
            DropTable("dbo.LectureFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LectureFiles",
                c => new
                    {
                        Lecture_Id = c.Int(nullable: false),
                        FilePath = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Lecture_Id, t.FilePath });
            
            CreateIndex("dbo.LectureFiles", "Lecture_Id");
            AddForeignKey("dbo.LectureFiles", "Lecture_Id", "dbo.Lectures", "Lecture_Id", cascadeDelete: true);
        }
    }
}
