namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentClass_ExtraDaysForPaymentMade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentClasses", "ExtraDaysForPaymentMade", c => c.Int(nullable: false, defaultValue: 4 * 365));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentClasses", "ExtraDaysForPaymentMade");
        }
    }
}
