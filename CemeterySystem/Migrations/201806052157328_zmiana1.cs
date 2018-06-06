namespace CemeterySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeadPersons", "FuneralID", "dbo.Funerals");
            DropIndex("dbo.DeadPersons", new[] { "FuneralID" });
            AlterColumn("dbo.DeadPersons", "FuneralID", c => c.Guid());
            CreateIndex("dbo.DeadPersons", "FuneralID");
            AddForeignKey("dbo.DeadPersons", "FuneralID", "dbo.Funerals", "FuneralID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeadPersons", "FuneralID", "dbo.Funerals");
            DropIndex("dbo.DeadPersons", new[] { "FuneralID" });
            AlterColumn("dbo.DeadPersons", "FuneralID", c => c.Guid(nullable: false));
            CreateIndex("dbo.DeadPersons", "FuneralID");
            AddForeignKey("dbo.DeadPersons", "FuneralID", "dbo.Funerals", "FuneralID", cascadeDelete: true);
        }
    }
}
