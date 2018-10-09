namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookmodelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 60));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 60));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Genre", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
