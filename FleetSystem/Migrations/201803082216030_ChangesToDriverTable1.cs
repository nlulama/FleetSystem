namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDriverTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Addresstype = c.Int(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        Address3 = c.String(),
                        Code = c.String(nullable: false),
                        TypeOfAddress_Id = c.Int(),
                        Driver_DriverId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.TypeOfAddress_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverId)
                .Index(t => t.TypeOfAddress_Id)
                .Index(t => t.Driver_DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Driver_DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Addresses", "TypeOfAddress_Id", "dbo.AddressTypes");
            DropIndex("dbo.Addresses", new[] { "Driver_DriverId" });
            DropIndex("dbo.Addresses", new[] { "TypeOfAddress_Id" });
            DropTable("dbo.Addresses");
        }
    }
}
