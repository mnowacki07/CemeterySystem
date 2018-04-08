namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BurialPlace_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BurialPlaces", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BurialPlaces", "IsDeleted");
        }
    }
}
