namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckListTableOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectChecklists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RouteId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        StartKm = c.Int(nullable: false),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModels", t => t.Model_Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Drivers", "InspectChecklist_Id", c => c.Int());
            CreateIndex("dbo.Drivers", "InspectChecklist_Id");
            AddForeignKey("dbo.Drivers", "InspectChecklist_Id", "dbo.InspectChecklists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InspectChecklists", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.InspectChecklists", "Model_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.Drivers", "InspectChecklist_Id", "dbo.InspectChecklists");
            DropIndex("dbo.InspectChecklists", new[] { "Model_Id" });
            DropIndex("dbo.InspectChecklists", new[] { "RouteId" });
            DropIndex("dbo.Drivers", new[] { "InspectChecklist_Id" });
            DropColumn("dbo.Drivers", "InspectChecklist_Id");
            DropTable("dbo.Routes");
            DropTable("dbo.InspectChecklists");
        }
    }
}
