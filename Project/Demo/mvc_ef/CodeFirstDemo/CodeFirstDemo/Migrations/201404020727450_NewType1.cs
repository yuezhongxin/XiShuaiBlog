namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewType1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewTypes", "Names", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewTypes", "Names", c => c.String(maxLength: 50));
        }
    }
}
