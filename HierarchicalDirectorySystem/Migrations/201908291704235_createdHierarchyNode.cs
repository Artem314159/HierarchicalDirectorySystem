namespace HierarchicalDirectorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdHierarchyNode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HierarchyNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HierarchyNodes");
        }
    }
}
