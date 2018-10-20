namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderviewmdeDeletd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderViewModels", "AplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderViewModels", "BookId", "dbo.Books");
            DropIndex("dbo.OrderViewModels", new[] { "BookId" });
            DropIndex("dbo.OrderViewModels", new[] { "AplicationUserId" });
            DropTable("dbo.OrderViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        AplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderViewModels", "AplicationUserId");
            CreateIndex("dbo.OrderViewModels", "BookId");
            AddForeignKey("dbo.OrderViewModels", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderViewModels", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
