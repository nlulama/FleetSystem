namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDriverTable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "DriverId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "Driver_DriverId1", c => c.Int());
            AddColumn("dbo.Drivers", "Address_Id", c => c.Int());
            CreateIndex("dbo.Addresses", "Driver_DriverId1");
            CreateIndex("dbo.Drivers", "Address_Id");
            AddForeignKey("dbo.Addresses", "Driver_DriverId1", "dbo.Drivers", "DriverId");
            AddForeignKey("dbo.Drivers", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Driver_DriverId1", "dbo.Drivers");
            DropIndex("dbo.Drivers", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "Driver_DriverId1" });
            DropColumn("dbo.Drivers", "Address_Id");
            DropColumn("dbo.Addresses", "Driver_DriverId1");
            DropColumn("dbo.Addresses", "DriverId");
        }
    }
}
