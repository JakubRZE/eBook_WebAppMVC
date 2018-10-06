namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBookandOrderModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(defaultValueSql: "GETDATE()"),
                        BookId = c.Int(nullable: false),
                        AplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AplicationUserId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AplicationUserId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "BookId", "dbo.Books");
            DropForeignKey("dbo.Orders", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AplicationUserId" });
            DropIndex("dbo.Orders", new[] { "BookId" });
            DropTable("dbo.Books");
            DropTable("dbo.Orders");
        }
    }
}
