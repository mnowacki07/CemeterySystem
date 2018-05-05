namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BurialPlaceBooker_FamilyMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BurialPlaceBookers", "FamilyMemberID", c => c.Guid());
            CreateIndex("dbo.BurialPlaceBookers", "FamilyMemberID");
            AddForeignKey("dbo.BurialPlaceBookers", "FamilyMemberID", "dbo.FamilyMembers", "FamilyMemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BurialPlaceBookers", "FamilyMemberID", "dbo.FamilyMembers");
            DropIndex("dbo.BurialPlaceBookers", new[] { "FamilyMemberID" });
            DropColumn("dbo.BurialPlaceBookers", "FamilyMemberID");
        }
    }
}
