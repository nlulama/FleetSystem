namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDriverTable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "TypeOfAddress_Id", "dbo.AddressTypes");
            DropIndex("dbo.Addresses", new[] { "TypeOfAddress_Id" });
            RenameColumn(table: "dbo.Addresses", name: "TypeOfAddress_Id", newName: "AddressTypeId");
            AddColumn("dbo.AddressTypes", "Address_Id", c => c.Int());
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "AddressTypeId");
            CreateIndex("dbo.AddressTypes", "Address_Id");
            AddForeignKey("dbo.AddressTypes", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Addresses", "Addresstype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Addresstype", c => c.Int(nullable: false));
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropForeignKey("dbo.AddressTypes", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AddressTypes", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            AlterColumn("dbo.Addresses", "AddressTypeId", c => c.Int());
            DropColumn("dbo.AddressTypes", "Address_Id");
            RenameColumn(table: "dbo.Addresses", name: "AddressTypeId", newName: "TypeOfAddress_Id");
            CreateIndex("dbo.Addresses", "TypeOfAddress_Id");
            AddForeignKey("dbo.Addresses", "TypeOfAddress_Id", "dbo.AddressTypes", "Id");
        }
    }
}
