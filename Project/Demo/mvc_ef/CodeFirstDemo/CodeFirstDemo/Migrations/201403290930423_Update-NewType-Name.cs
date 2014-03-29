namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNewTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewTypes", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewTypes", "Name", c => c.String());
        }
    }
}
