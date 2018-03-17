namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentClasses",
                c => new
                    {
                        PaymentClassID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaymentClassID);
            
            AddColumn("dbo.BurialPlaces", "PaymentClassID", c => c.Guid(nullable: false));
            CreateIndex("dbo.BurialPlaces", "PaymentClassID");
            AddForeignKey("dbo.BurialPlaces", "PaymentClassID", "dbo.PaymentClasses", "PaymentClassID", cascadeDelete: true);
            DropColumn("dbo.BurialPlaces", "PaymentClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BurialPlaces", "PaymentClass", c => c.Int(nullable: false));
            DropForeignKey("dbo.BurialPlaces", "PaymentClassID", "dbo.PaymentClasses");
            DropIndex("dbo.BurialPlaces", new[] { "PaymentClassID" });
            DropColumn("dbo.BurialPlaces", "PaymentClassID");
            DropTable("dbo.PaymentClasses");
        }
    }
}
