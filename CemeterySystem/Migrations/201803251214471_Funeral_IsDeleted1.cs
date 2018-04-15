namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Funeral_IsDeleted1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funerals", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funerals", "IsDeleted");
        }
    }
}
