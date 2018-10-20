namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rankAddedToOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Rank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Rank");
        }
    }
}
