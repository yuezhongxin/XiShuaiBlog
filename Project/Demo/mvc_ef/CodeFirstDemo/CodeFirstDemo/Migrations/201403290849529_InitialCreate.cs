namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        NewTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewId)
                .ForeignKey("dbo.NewTypes", t => t.NewTypeId, cascadeDelete: true)
                .Index(t => t.NewTypeId);
            
            CreateTable(
                "dbo.NewTypes",
                c => new
                    {
                        NewTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NewTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewTypeId", "dbo.NewTypes");
            DropIndex("dbo.News", new[] { "NewTypeId" });
            DropTable("dbo.NewTypes");
            DropTable("dbo.News");
        }
    }
}
