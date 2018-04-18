namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleMakeAndModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleMakeId = c.Int(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId, cascadeDelete: true)
                .Index(t => t.VehicleMakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMakes");
        }
    }
}
