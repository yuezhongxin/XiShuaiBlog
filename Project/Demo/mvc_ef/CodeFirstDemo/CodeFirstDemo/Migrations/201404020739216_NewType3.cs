namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewType3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewTypes", "Names", c => c.String(maxLength: 50));
            DropColumn("dbo.NewTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.NewTypes", "Names");
        }
    }
}
