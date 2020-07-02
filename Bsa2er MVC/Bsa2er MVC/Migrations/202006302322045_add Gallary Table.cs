namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGallaryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        G_Id = c.Int(nullable: false, identity: true),
                        Gallery_path = c.String(),
                    })
                .PrimaryKey(t => t.G_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
