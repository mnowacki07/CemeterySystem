namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BurialPlaceBooker_NullableData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BurialPlaceBookers", "FirstName", c => c.String());
            AlterColumn("dbo.BurialPlaceBookers", "LastName", c => c.String());
            AlterColumn("dbo.BurialPlaceBookers", "BirthDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.BurialPlaceBookers", "Gender", c => c.Int());
            AlterColumn("dbo.BurialPlaceBookers", "PESEL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BurialPlaceBookers", "PESEL", c => c.String(nullable: false));
            AlterColumn("dbo.BurialPlaceBookers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.BurialPlaceBookers", "BirthDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.BurialPlaceBookers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.BurialPlaceBookers", "FirstName", c => c.String(nullable: false));
        }
    }
}
