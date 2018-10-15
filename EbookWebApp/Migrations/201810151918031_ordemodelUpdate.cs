namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordemodelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Rank", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Rank", c => c.Int(nullable: false));
        }
    }
}
