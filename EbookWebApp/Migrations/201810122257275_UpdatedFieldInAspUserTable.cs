namespace EbookWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFieldInAspUserTable : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "RegistrationDate", c => c.Int(nullable: false));
        }
    }
}
