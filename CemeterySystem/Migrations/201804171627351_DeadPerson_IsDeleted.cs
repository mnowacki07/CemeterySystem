namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeadPerson_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeadPersons", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeadPersons", "IsDeleted");
        }
    }
}
