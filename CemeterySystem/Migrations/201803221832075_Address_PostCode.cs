namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address_PostCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "PostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "PostCode");
        }
    }
}
