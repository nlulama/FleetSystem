namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "PostalAddress1");
            DropColumn("dbo.Drivers", "PostalAddress2");
            DropColumn("dbo.Drivers", "PostalAddress3");
            DropColumn("dbo.Drivers", "PostalCode");
            DropColumn("dbo.Drivers", "PhusicalAddress1");
            DropColumn("dbo.Drivers", "PhusicalAddress2");
            DropColumn("dbo.Drivers", "PhusicalAddress3");
            DropColumn("dbo.Drivers", "PhysicalCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "PhysicalCode", c => c.String());
            AddColumn("dbo.Drivers", "PhusicalAddress3", c => c.String());
            AddColumn("dbo.Drivers", "PhusicalAddress2", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "PhusicalAddress1", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "PostalAddress3", c => c.String());
            AddColumn("dbo.Drivers", "PostalAddress2", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "PostalAddress1", c => c.String(nullable: false));
        }
    }
}
