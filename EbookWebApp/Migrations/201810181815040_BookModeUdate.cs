namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModeUdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Overall", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Overall", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
