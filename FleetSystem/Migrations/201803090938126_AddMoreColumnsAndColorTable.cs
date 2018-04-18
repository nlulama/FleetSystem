namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreColumnsAndColorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VehicleModels", "ModelYear", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleModels", "RegNo", c => c.String());
            AddColumn("dbo.VehicleModels", "NoOfPassengers", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleModels", "ArrivalKms", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleModels", "DateArrived", c => c.DateTime(nullable: false));
            AddColumn("dbo.VehicleModels", "VehicleColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleModels", "VehicleColorId");
            AddForeignKey("dbo.VehicleModels", "VehicleColorId", "dbo.VehicleColors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleColorId", "dbo.VehicleColors");
            DropIndex("dbo.VehicleModels", new[] { "VehicleColorId" });
            DropColumn("dbo.VehicleModels", "VehicleColorId");
            DropColumn("dbo.VehicleModels", "DateArrived");
            DropColumn("dbo.VehicleModels", "ArrivalKms");
            DropColumn("dbo.VehicleModels", "NoOfPassengers");
            DropColumn("dbo.VehicleModels", "RegNo");
            DropColumn("dbo.VehicleModels", "ModelYear");
            DropTable("dbo.VehicleColors");
        }
    }
}
