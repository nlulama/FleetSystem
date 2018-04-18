namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDriverTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Drivers", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "GenderId");
            AddForeignKey("dbo.Drivers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Drivers", new[] { "GenderId" });
            DropColumn("dbo.Drivers", "GenderId");
            DropTable("dbo.Genders");
            DropTable("dbo.AddressTypes");
        }
    }
}
