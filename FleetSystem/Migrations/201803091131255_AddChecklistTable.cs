namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChecklistTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CheckListYN = c.Int(nullable: false),
                        Comments = c.String(),
                        ChecklistYesNo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChecklistYesNoes", t => t.ChecklistYesNo_Id)
                .Index(t => t.ChecklistYesNo_Id);
            
            CreateTable(
                "dbo.ChecklistYesNoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checklists", "ChecklistYesNo_Id", "dbo.ChecklistYesNoes");
            DropIndex("dbo.Checklists", new[] { "ChecklistYesNo_Id" });
            DropTable("dbo.ChecklistYesNoes");
            DropTable("dbo.Checklists");
        }
    }
}
