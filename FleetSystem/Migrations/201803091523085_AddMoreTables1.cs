namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreTables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        Odometer = c.Int(nullable: false),
                        StoppingPoint = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                        Depart = c.DateTime(nullable: false),
                        PassengersIn = c.Int(nullable: false),
                        PassengersOut = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripRecords", "TripId", "dbo.Trips");
            DropForeignKey("dbo.TripRecords", "DriverId", "dbo.Drivers");
            DropIndex("dbo.TripRecords", new[] { "DriverId" });
            DropIndex("dbo.TripRecords", new[] { "TripId" });
            DropTable("dbo.TripRecords");
        }
    }
}
