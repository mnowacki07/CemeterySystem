namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Service_BookedService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookedServices",
                c => new
                    {
                        BookedServiceID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        PriceGross = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        BurialPlaceID = c.Guid(nullable: false),
                        FamilyMemberID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookedServiceID)
                .ForeignKey("dbo.BurialPlaces", t => t.BurialPlaceID, cascadeDelete: true)
                .ForeignKey("dbo.FamilyMembers", t => t.FamilyMemberID, cascadeDelete: true)
                .Index(t => t.BurialPlaceID)
                .Index(t => t.FamilyMemberID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        PriceGross = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookedServices", "FamilyMemberID", "dbo.FamilyMembers");
            DropForeignKey("dbo.BookedServices", "BurialPlaceID", "dbo.BurialPlaces");
            DropIndex("dbo.BookedServices", new[] { "FamilyMemberID" });
            DropIndex("dbo.BookedServices", new[] { "BurialPlaceID" });
            DropTable("dbo.Services");
            DropTable("dbo.BookedServices");
        }
    }
}
