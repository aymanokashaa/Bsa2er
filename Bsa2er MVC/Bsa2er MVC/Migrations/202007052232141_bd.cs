namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PdfFilepath = c.String(),
                        imageFilePath = c.String(),
                        Booksection_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Booksections", t => t.Booksection_id)
                .Index(t => t.Booksection_id);
            
            CreateTable(
                "dbo.Booksections",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        imagepath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Exam_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        grads = c.Int(nullable: false),
                        NumberOfQuestions = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Exam_Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        Program_MainImage = c.String(),
                        Program_Title = c.String(),
                        Program_Duration = c.String(),
                        Program_Advantages = c.String(),
                        Program_Goals = c.String(),
                        Program_ImagePath = c.String(),
                        Program_Body = c.String(),
                        Program_VideoLink = c.String(),
                        Program_TargetGroup = c.String(),
                        Program_Type = c.Int(nullable: false),
                        NumOfLecture = c.Int(nullable: false),
                        Ins_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("dbo.Instructors", t => t.Ins_Id)
                .Index(t => t.Ins_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InsId = c.String(nullable: false, maxLength: 128),
                        Degree = c.String(),
                    })
                .PrimaryKey(t => t.InsId)
                .ForeignKey("dbo.AspNetUsers", t => t.InsId)
                .Index(t => t.InsId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                        Qualification = c.String(),
                        dateofbirth = c.DateTime(),
                        pathofimage = c.String(),
                        gender = c.String(),
                        fullname = c.String(),
                        birthcountry = c.String(),
                        dataOfRegister = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Lecture_Id = c.Int(nullable: false, identity: true),
                        Lecture_Title = c.String(),
                        Lecture_VideoLink = c.String(),
                        Lecture_SoundLink = c.String(),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Lecture_Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.StudentsPrograms",
                c => new
                    {
                        Std_Id = c.String(nullable: false, maxLength: 128),
                        Program_Id = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        ProgramGrade = c.Int(nullable: false),
                        Program_Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Std_Id, t.Program_Id })
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Std_Id, cascadeDelete: true)
                .Index(t => t.Std_Id)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StdId = c.String(nullable: false, maxLength: 128),
                        WhereYouHearAboutUs = c.String(),
                    })
                .PrimaryKey(t => t.StdId)
                .ForeignKey("dbo.AspNetUsers", t => t.StdId)
                .Index(t => t.StdId);
            
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
                "dbo.Galleries",
                c => new
                    {
                        G_Id = c.Int(nullable: false, identity: true),
                        Gallery_path = c.String(),
                    })
                .PrimaryKey(t => t.G_Id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        body = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpAddress = c.String(),
                        DateTimeOfVisit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Questions", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Exams", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.StudentsPrograms", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "StdId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentsPrograms", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Lectures", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.Programs", "Ins_Id", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "InsId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "Booksection_id", "dbo.Booksections");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Questions", new[] { "Exam_Id" });
            DropIndex("dbo.Students", new[] { "StdId" });
            DropIndex("dbo.StudentsPrograms", new[] { "Program_Id" });
            DropIndex("dbo.StudentsPrograms", new[] { "Std_Id" });
            DropIndex("dbo.Lectures", new[] { "Program_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Instructors", new[] { "InsId" });
            DropIndex("dbo.Programs", new[] { "Ins_Id" });
            DropIndex("dbo.Exams", new[] { "Program_Id" });
            DropIndex("dbo.Books", new[] { "Booksection_id" });
            DropTable("dbo.Visitors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.news");
            DropTable("dbo.Galleries");
            DropTable("dbo.Questions");
            DropTable("dbo.Students");
            DropTable("dbo.StudentsPrograms");
            DropTable("dbo.Lectures");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Instructors");
            DropTable("dbo.Programs");
            DropTable("dbo.Exams");
            DropTable("dbo.Booksections");
            DropTable("dbo.Books");
        }
    }
}
