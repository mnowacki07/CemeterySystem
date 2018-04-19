namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeadPerosn_FamilyMember : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyMembers", "DeadPersonID", "dbo.DeadPersons");
            DropIndex("dbo.FamilyMembers", new[] { "DeadPersonID" });
            AddColumn("dbo.DeadPersons", "FamilyMemberID", c => c.Guid());
            CreateIndex("dbo.DeadPersons", "FamilyMemberID");
            AddForeignKey("dbo.DeadPersons", "FamilyMemberID", "dbo.FamilyMembers", "FamilyMemberID");
            DropColumn("dbo.FamilyMembers", "DeadPersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FamilyMembers", "DeadPersonID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.DeadPersons", "FamilyMemberID", "dbo.FamilyMembers");
            DropIndex("dbo.DeadPersons", new[] { "FamilyMemberID" });
            DropColumn("dbo.DeadPersons", "FamilyMemberID");
            CreateIndex("dbo.FamilyMembers", "DeadPersonID");
            AddForeignKey("dbo.FamilyMembers", "DeadPersonID", "dbo.DeadPersons", "DeadPersonID", cascadeDelete: true);
        }
    }
}
