namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AplicationUserId" });
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "AplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "AplicationUserId");
            AddForeignKey("dbo.Orders", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AplicationUserId" });
            AlterColumn("dbo.Orders", "AplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Books", "Genre", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            CreateIndex("dbo.Orders", "AplicationUserId");
            AddForeignKey("dbo.Orders", "AplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
