namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverallPropAddedToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Overall", c => c.Decimal(nullable: true, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Overall");
        }
    }
}
