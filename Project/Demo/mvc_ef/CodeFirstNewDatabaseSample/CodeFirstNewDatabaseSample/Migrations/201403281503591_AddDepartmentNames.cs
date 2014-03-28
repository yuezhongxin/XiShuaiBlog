namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Name");
        }
    }
}
