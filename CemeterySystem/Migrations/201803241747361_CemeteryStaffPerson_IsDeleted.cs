namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CemeteryStaffPerson_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CemeteryStaffPersons", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CemeteryStaffPersons", "IsDeleted");
        }
    }
}
