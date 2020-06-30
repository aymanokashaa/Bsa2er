namespace Bsa2er_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "dateofbirth", c => c.DateTime());
        }
        
      //  public override void Down()
        //{
          //  AlterColumn("dbo.AspNetUsers", "dateofbirth", c => c.DateTime(nullable: false));
        //}
    }
}
