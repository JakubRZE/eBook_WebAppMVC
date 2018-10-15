namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rankAddedToOrderModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "AplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "BookId", "dbo.Books");
            DropIndex("dbo.Ratings", new[] { "BookId" });
            DropIndex("dbo.Ratings", new[] { "AplicationUserId" });
            AddColumn("dbo.Orders", "Rank", c => c.Int(nullable: false));
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Orders", "Rank");
            CreateIndex("dbo.Ratings", "AplicationUserId");
            CreateIndex("dbo.Ratings", "BookId");
            AddForeignKey("dbo.Ratings", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "AplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
