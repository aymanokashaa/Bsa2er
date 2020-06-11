namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Cer_Id = c.Int(nullable: false, identity: true),
                        Cer_Title = c.String(),
                        Cer_Body = c.String(),
                        Cer_File = c.Binary(),
                    })
                .PrimaryKey(t => t.Cer_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Program_Id = c.Int(nullable: false),
                        Program_Title = c.String(),
                        Program_Duration = c.String(),
                        Program_Advantages = c.String(),
                        Program_Goals = c.String(),
                        Program_Image = c.Binary(),
                        Program_VideoLink = c.String(),
                        Program_TargetGroup = c.String(),
                        Program_Type = c.Int(nullable: false),
                        NumOfLecture = c.Int(nullable: false),
                        Ins_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Program_Id)
                .ForeignKey("dbo.Certifications", t => t.Program_Id)
                .ForeignKey("dbo.Exams", t => t.Program_Id)
                .ForeignKey("dbo.Instructors", t => t.Ins_Id, cascadeDelete: true)
                .Index(t => t.Program_Id)
                .Index(t => t.Ins_Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Exam_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        grads = c.Int(nullable: false),
                        NumberOfQuestions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Exam_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Q_Id = c.Int(nullable: false, identity: true),
                        QuestionType = c.Int(nullable: false),
                        Q_Marks = c.Int(nullable: false),
                        Q_Header = c.String(),
                        Q_Answer = c.String(),
                        ChoiceOne = c.String(),
                        ChoiceTwo = c.String(),
                        ChoiceThree = c.String(),
                        ChoiceFour = c.String(),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Q_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id, cascadeDelete: true)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Ins_Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Ins_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Std_Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Std_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.StudentsPrograms",
                c => new
                    {
                        Std_Id = c.Int(nullable: false),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Std_Id, t.Program_Id })
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Std_Id, cascadeDelete: true)
                .Index(t => t.Std_Id)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Lecture_Id = c.Int(nullable: false, identity: true),
                        Lecture_Title = c.String(),
                        Lecture_VideoLink = c.String(),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Lecture_Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.LectureFiles",
                c => new
                    {
                        Lecture_Id = c.Int(nullable: false),
                        File = c.Binary(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Lecture_Id, t.File })
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id, cascadeDelete: true)
                .Index(t => t.Lecture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.LectureFiles", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Exams");
            DropForeignKey("dbo.Questions", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Certifications");
            DropIndex("dbo.LectureFiles", new[] { "Lecture_Id" });
            DropIndex("dbo.Lectures", new[] { "Program_Id" });
            DropIndex("dbo.StudentsPrograms", new[] { "Program_Id" });
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Instructors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Questions", new[] { "Exam_Id" });
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropIndex("dbo.Programs", new[] { "Program_Id" });
            DropTable("dbo.LectureFiles");
            DropTable("dbo.Lectures");
            DropTable("dbo.StudentsPrograms");
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.Questions");
            DropTable("dbo.Exams");
            DropTable("dbo.Programs");
            DropTable("dbo.Certifications");
        }
    }
}
