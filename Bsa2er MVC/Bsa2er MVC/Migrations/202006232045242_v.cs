namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Certifications");
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Exams");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropIndex("dbo.Programs", new[] { "Program_Id" });
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            RenameColumn(table: "dbo.Instructors", name: "ApplicationUser_Id", newName: "InsId");
            RenameColumn(table: "dbo.Students", name: "ApplicationUser_Id", newName: "StdId");
            RenameIndex(table: "dbo.Instructors", name: "IX_ApplicationUser_Id", newName: "IX_InsId");
            RenameIndex(table: "dbo.Students", name: "IX_ApplicationUser_Id", newName: "IX_StdId");
            DropPrimaryKey("dbo.Instructors");
            DropPrimaryKey("dbo.Programs");
            DropPrimaryKey("dbo.LectureFiles");
            DropPrimaryKey("dbo.StudentsPrograms");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Instructors", "Degree", c => c.String());
            AddColumn("dbo.Programs", "Program_ImagePath", c => c.String());
            AddColumn("dbo.Exams", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exams", "Program_Id", c => c.Int(nullable: false));
            AddColumn("dbo.LectureFiles", "FilePath", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.StudentsPrograms", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentsPrograms", "EndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentsPrograms", "ProgramGrade", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "WhereYouHearAboutUs", c => c.String());
            AlterColumn("dbo.Programs", "Program_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Programs", "Ins_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.StudentsPrograms", "Std_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Instructors", "InsId");
            AddPrimaryKey("dbo.Programs", "Program_Id");
            AddPrimaryKey("dbo.LectureFiles", new[] { "Lecture_Id", "FilePath" });
            AddPrimaryKey("dbo.StudentsPrograms", new[] { "Std_Id", "Program_Id" });
            AddPrimaryKey("dbo.Students", "StdId");
            CreateIndex("dbo.Exams", "Program_Id");
            CreateIndex("dbo.Programs", "Ins_Id");
            CreateIndex("dbo.StudentsPrograms", "Std_Id");
            AddForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors", "InsId");
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students", "StdId", cascadeDelete: true);
            DropColumn("dbo.Instructors", "Ins_Id");
            DropColumn("dbo.Programs", "Program_Image");
            DropColumn("dbo.LectureFiles", "File");
            DropColumn("dbo.Students", "Std_Id");
            DropTable("dbo.Certifications");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Students", "Std_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.LectureFiles", "File", c => c.Binary(nullable: false, maxLength: 128));
            AddColumn("dbo.Programs", "Program_Image", c => c.Binary());
            AddColumn("dbo.Instructors", "Ins_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropIndex("dbo.Exams", new[] { "Program_Id" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.StudentsPrograms");
            DropPrimaryKey("dbo.LectureFiles");
            DropPrimaryKey("dbo.Programs");
            DropPrimaryKey("dbo.Instructors");
            AlterColumn("dbo.StudentsPrograms", "Std_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Programs", "Ins_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Programs", "Program_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "WhereYouHearAboutUs");
            DropColumn("dbo.StudentsPrograms", "ProgramGrade");
            DropColumn("dbo.StudentsPrograms", "EndDateTime");
            DropColumn("dbo.StudentsPrograms", "StartDateTime");
            DropColumn("dbo.LectureFiles", "FilePath");
            DropColumn("dbo.Exams", "Program_Id");
            DropColumn("dbo.Exams", "Active");
            DropColumn("dbo.Programs", "Program_ImagePath");
            DropColumn("dbo.Instructors", "Degree");
            AddPrimaryKey("dbo.Students", "Std_Id");
            AddPrimaryKey("dbo.StudentsPrograms", new[] { "Std_Id", "Program_Id" });
            AddPrimaryKey("dbo.LectureFiles", new[] { "Lecture_Id", "File" });
            AddPrimaryKey("dbo.Programs", "Program_Id");
            AddPrimaryKey("dbo.Instructors", "Ins_Id");
            RenameIndex(table: "dbo.Students", name: "IX_StdId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Instructors", name: "IX_InsId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Students", name: "StdId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Instructors", name: "InsId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.StudentsPrograms", "Std_Id");
            CreateIndex("dbo.Programs", "Ins_Id");
            CreateIndex("dbo.Programs", "Program_Id");
            AddForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students", "Std_Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Programs", "Program_Id", "dbo.Exams", "Exam_Id");
            AddForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors", "Ins_Id", cascadeDelete: true);
            AddForeignKey("dbo.Programs", "Program_Id", "dbo.Certifications", "Cer_Id");
        }
    }
}
