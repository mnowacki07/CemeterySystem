namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FamilyMember_With_AspNetUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FamilyMemberID", c => c.Guid(nullable: true));
            CreateIndex("dbo.AspNetUsers", "FamilyMemberID");
            AddForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers", "FamilyMemberID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers");
            DropIndex("dbo.AspNetUsers", new[] { "FamilyMemberID" });
            DropColumn("dbo.AspNetUsers", "FamilyMemberID");
        }
    }
}
