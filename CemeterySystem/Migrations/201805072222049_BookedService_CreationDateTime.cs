namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookedService_CreationDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookedServices", "CreationDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookedServices", "CreationDateTime");
        }
    }
}
