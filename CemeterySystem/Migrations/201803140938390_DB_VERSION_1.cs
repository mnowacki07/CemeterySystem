namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_VERSION_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        CustomAddressID = c.Guid(nullable: false),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        FlatNumber = c.String(),
                        Town = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomAddressID);
            
            CreateTable(
                "dbo.BurialPlaceBookers",
                c => new
                    {
                        BurialPlaceBookerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Int(nullable: false),
                        PESEL = c.String(nullable: false),
                        BurialPlaceID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BurialPlaceBookerID)
                .ForeignKey("dbo.BurialPlaces", t => t.BurialPlaceID, cascadeDelete: true)
                .Index(t => t.BurialPlaceID);
            
            CreateTable(
                "dbo.BurialPlaces",
                c => new
                    {
                        BurialPlaceID = c.Guid(nullable: false),
                        FieldNumber = c.String(nullable: false),
                        GraveNumber = c.String(),
                        Type = c.Int(nullable: false),
                        PaymentDate = c.DateTime(storeType: "date"),
                        PaymentClass = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BurialPlaceID);
            
            CreateTable(
                "dbo.CemeteryStaffPersons",
                c => new
                    {
                        CemeteryStaffPersonID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        PESEL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CemeteryStaffPersonID);
            
            CreateTable(
                "dbo.DeadPersons",
                c => new
                    {
                        DeadPersonID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PESEL = c.String(),
                        Gender = c.Int(nullable: false),
                        BurialPlaceID = c.Guid(nullable: false),
                        FuneralID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DeadPersonID)
                .ForeignKey("dbo.BurialPlaces", t => t.BurialPlaceID, cascadeDelete: true)
                .ForeignKey("dbo.Funerals", t => t.FuneralID, cascadeDelete: true)
                .Index(t => t.BurialPlaceID)
                .Index(t => t.FuneralID);
            
            CreateTable(
                "dbo.Funerals",
                c => new
                    {
                        FuneralID = c.Guid(nullable: false),
                        FuneralDate = c.DateTime(nullable: false, storeType: "date"),
                        FuneralCompanyID = c.Guid(nullable: false),
                        CemeteryStaffPersonID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FuneralID)
                .ForeignKey("dbo.CemeteryStaffPersons", t => t.CemeteryStaffPersonID, cascadeDelete: true)
                .ForeignKey("dbo.FuneralCompanies", t => t.FuneralCompanyID, cascadeDelete: true)
                .Index(t => t.FuneralCompanyID)
                .Index(t => t.CemeteryStaffPersonID);
            
            CreateTable(
                "dbo.FuneralCompanies",
                c => new
                    {
                        FuneralCompanyID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        LicenseNumber = c.String(nullable: false),
                        AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FuneralCompanyID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        FamilyMemberID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        AddressID = c.Guid(nullable: false),
                        DeadPersonID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FamilyMemberID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.DeadPersons", t => t.DeadPersonID, cascadeDelete: false)
                .Index(t => t.AddressID)
                .Index(t => t.DeadPersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "DeadPersonID", "dbo.DeadPersons");
            DropForeignKey("dbo.FamilyMembers", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.DeadPersons", "FuneralID", "dbo.Funerals");
            DropForeignKey("dbo.Funerals", "FuneralCompanyID", "dbo.FuneralCompanies");
            DropForeignKey("dbo.FuneralCompanies", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Funerals", "CemeteryStaffPersonID", "dbo.CemeteryStaffPersons");
            DropForeignKey("dbo.DeadPersons", "BurialPlaceID", "dbo.BurialPlaces");
            DropForeignKey("dbo.BurialPlaceBookers", "BurialPlaceID", "dbo.BurialPlaces");
            DropIndex("dbo.FamilyMembers", new[] { "DeadPersonID" });
            DropIndex("dbo.FamilyMembers", new[] { "AddressID" });
            DropIndex("dbo.FuneralCompanies", new[] { "AddressID" });
            DropIndex("dbo.Funerals", new[] { "CemeteryStaffPersonID" });
            DropIndex("dbo.Funerals", new[] { "FuneralCompanyID" });
            DropIndex("dbo.DeadPersons", new[] { "FuneralID" });
            DropIndex("dbo.DeadPersons", new[] { "BurialPlaceID" });
            DropIndex("dbo.BurialPlaceBookers", new[] { "BurialPlaceID" });
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.FuneralCompanies");
            DropTable("dbo.Funerals");
            DropTable("dbo.DeadPersons");
            DropTable("dbo.CemeteryStaffPersons");
            DropTable("dbo.BurialPlaces");
            DropTable("dbo.BurialPlaceBookers");
            DropTable("dbo.Addresses");
        }
    }
}
