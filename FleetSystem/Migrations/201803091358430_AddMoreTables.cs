namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ServiceNo = c.String(),
                        FromId = c.Int(nullable: false),
                        ToId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        StartKm = c.Int(nullable: false),
                        EndKm = c.Int(nullable: false),
                        FromAddress_Id = c.Int(),
                        ToAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.FromAddress_Id)
                .ForeignKey("dbo.Destinations", t => t.ToAddress_Id)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.FromAddress_Id)
                .Index(t => t.ToAddress_Id);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToFrom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Drivers", "Trip_Id", c => c.Int());
            CreateIndex("dbo.Drivers", "Trip_Id");
            AddForeignKey("dbo.Drivers", "Trip_Id", "dbo.Trips", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "VehicleId", "dbo.VehicleModels");
            DropForeignKey("dbo.Trips", "ToAddress_Id", "dbo.Destinations");
            DropForeignKey("dbo.Trips", "FromAddress_Id", "dbo.Destinations");
            DropForeignKey("dbo.Drivers", "Trip_Id", "dbo.Trips");
            DropIndex("dbo.Trips", new[] { "ToAddress_Id" });
            DropIndex("dbo.Trips", new[] { "FromAddress_Id" });
            DropIndex("dbo.Trips", new[] { "VehicleId" });
            DropIndex("dbo.Drivers", new[] { "Trip_Id" });
            DropColumn("dbo.Drivers", "Trip_Id");
            DropTable("dbo.Destinations");
            DropTable("dbo.Trips");
        }
    }
}
