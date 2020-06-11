namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.news", "Book_Id", "dbo.Books");
            DropIndex("dbo.news", new[] { "Book_Id" });
            DropColumn("dbo.news", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.news", "Book_Id", c => c.Int());
            CreateIndex("dbo.news", "Book_Id");
            AddForeignKey("dbo.news", "Book_Id", "dbo.Books", "Id");
        }
    }
}
