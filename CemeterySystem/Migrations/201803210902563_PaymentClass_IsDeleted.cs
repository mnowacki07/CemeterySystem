namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentClass_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentClasses", "IsDeleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentClasses", "IsDeleted");
        }
    }
}
