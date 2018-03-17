namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_FamilyMember_Nullable_ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers");
            DropIndex("dbo.AspNetUsers", new[] { "FamilyMemberID" });
            AlterColumn("dbo.AspNetUsers", "FamilyMemberID", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "FamilyMemberID");
            AddForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers", "FamilyMemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers");
            DropIndex("dbo.AspNetUsers", new[] { "FamilyMemberID" });
            AlterColumn("dbo.AspNetUsers", "FamilyMemberID", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetUsers", "FamilyMemberID");
            AddForeignKey("dbo.AspNetUsers", "FamilyMemberID", "dbo.FamilyMembers", "FamilyMemberID", cascadeDelete: true);
        }
    }
}
