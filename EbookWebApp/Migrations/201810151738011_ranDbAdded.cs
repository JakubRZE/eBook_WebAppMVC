namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ranDbAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        AplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AplicationUserId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "BookId", "dbo.Books");
            DropForeignKey("dbo.Ratings", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "AplicationUserId" });
            DropIndex("dbo.Ratings", new[] { "BookId" });
            DropTable("dbo.Ratings");
        }
    }
}
