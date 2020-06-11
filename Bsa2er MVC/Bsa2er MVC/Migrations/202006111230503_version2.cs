namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        body = c.String(),
                        ImagePath = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            AddColumn("dbo.Books", "Booksection_id", c => c.Int());
            CreateIndex("dbo.Books", "Booksection_id");
            AddForeignKey("dbo.Books", "Booksection_id", "dbo.Booksections", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Booksection_id", "dbo.Booksections");
            DropIndex("dbo.news", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Booksection_id" });
            DropColumn("dbo.Books", "Booksection_id");
            DropTable("dbo.news");
            DropTable("dbo.Booksections");
        }
    }
}
