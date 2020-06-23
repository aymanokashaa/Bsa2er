namespace Bsa2er_MVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class remove_CertificationTable_Edit_studentPrograme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "Program_Id", "dbo.Certifications");
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropIndex("dbo.Programs", new[] { "Program_Id" });
            DropPrimaryKey("dbo.Programs");
            AddColumn("dbo.StudentsPrograms", "ProgramGrade", c => c.Int(nullable: false));
            AlterColumn("dbo.Programs", "Program_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Programs", "Program_Id");
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
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
                    Cer_FilePath = c.String(),
                })
                .PrimaryKey(t => t.Cer_Id);

            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropPrimaryKey("dbo.Programs");
            AlterColumn("dbo.Programs", "Program_Id", c => c.Int(nullable: false));
            DropColumn("dbo.StudentsPrograms", "ProgramGrade");
            AddPrimaryKey("dbo.Programs", "Program_Id");
            CreateIndex("dbo.Programs", "Program_Id");
            AddForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Program_Id", "dbo.Programs", "Program_Id", cascadeDelete: true);
            AddForeignKey("dbo.Programs", "Program_Id", "dbo.Certifications", "Cer_Id");
        }
    }
}
