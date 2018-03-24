namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuneralCompany_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuneralCompanies", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuneralCompanies", "IsDeleted");
        }
    }
}
