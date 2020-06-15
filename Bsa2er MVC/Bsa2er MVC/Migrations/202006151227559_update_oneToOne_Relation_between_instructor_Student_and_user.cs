namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_oneToOne_Relation_between_instructor_Student_and_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            RenameColumn(table: "dbo.Instructors", name: "ApplicationUser_Id", newName: "InsId");
            RenameColumn(table: "dbo.Students", name: "ApplicationUser_Id", newName: "StdId");
            RenameIndex(table: "dbo.Instructors", name: "IX_ApplicationUser_Id", newName: "IX_InsId");
            RenameIndex(table: "dbo.Students", name: "IX_ApplicationUser_Id", newName: "IX_StdId");
            DropPrimaryKey("dbo.Instructors");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.StudentsPrograms");
            DropPrimaryKey("dbo.LectureFiles");
            AddColumn("dbo.Certifications", "Cer_FilePath", c => c.String());
            AddColumn("dbo.Programs", "Program_ImagePath", c => c.String());
            AddColumn("dbo.Instructors", "Degree", c => c.String());
            AddColumn("dbo.Students", "WhereYouHearAboutUs", c => c.String());
            AddColumn("dbo.LectureFiles", "FilePath", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Programs", "Ins_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.StudentsPrograms", "Std_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Instructors", "InsId");
            AddPrimaryKey("dbo.Students", "StdId");
            AddPrimaryKey("dbo.StudentsPrograms", new[] { "Std_Id", "Program_Id" });
            AddPrimaryKey("dbo.LectureFiles", new[] { "Lecture_Id", "FilePath" });
            CreateIndex("dbo.Programs", "Ins_Id");
            CreateIndex("dbo.StudentsPrograms", "Std_Id");
            AddForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors", "InsId");
            AddForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students", "StdId", cascadeDelete: true);
            DropColumn("dbo.Certifications", "Cer_File");
            DropColumn("dbo.Programs", "Program_Image");
            DropColumn("dbo.Instructors", "Ins_Id");
            DropColumn("dbo.Students", "Std_Id");
            DropColumn("dbo.LectureFiles", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LectureFiles", "File", c => c.Binary(nullable: false, maxLength: 128));
            AddColumn("dbo.Students", "Std_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Instructors", "Ins_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Programs", "Program_Image", c => c.Binary());
            AddColumn("dbo.Certifications", "Cer_File", c => c.Binary());
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropPrimaryKey("dbo.LectureFiles");
            DropPrimaryKey("dbo.StudentsPrograms");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Instructors");
            AlterColumn("dbo.StudentsPrograms", "Std_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Programs", "Ins_Id", c => c.Int(nullable: false));
            DropColumn("dbo.LectureFiles", "FilePath");
            DropColumn("dbo.Students", "WhereYouHearAboutUs");
            DropColumn("dbo.Instructors", "Degree");
            DropColumn("dbo.Programs", "Program_ImagePath");
            DropColumn("dbo.Certifications", "Cer_FilePath");
            AddPrimaryKey("dbo.LectureFiles", new[] { "Lecture_Id", "File" });
            AddPrimaryKey("dbo.StudentsPrograms", new[] { "Std_Id", "Program_Id" });
            AddPrimaryKey("dbo.Students", "Std_Id");
            AddPrimaryKey("dbo.Instructors", "Ins_Id");
            RenameIndex(table: "dbo.Students", name: "IX_StdId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Instructors", name: "IX_InsId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Students", name: "StdId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Instructors", name: "InsId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.StudentsPrograms", "Std_Id");
            CreateIndex("dbo.Programs", "Ins_Id");
            AddForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students", "Std_Id", cascadeDelete: true);
            AddForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors", "Ins_Id", cascadeDelete: true);
        }
    }
}
