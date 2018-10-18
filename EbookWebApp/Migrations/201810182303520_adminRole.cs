namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.OrderViewModels", "BookId", "dbo.Books");
            DropForeignKey("dbo.OrderViewModels", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.OrderViewModels", new[] { "AplicationUserId" });
            DropIndex("dbo.OrderViewModels", new[] { "BookId" });
            DropTable("dbo.OrderViewModels");
        }
    }
}
