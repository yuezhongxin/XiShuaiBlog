namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewType4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.NewTypes", name: "Names", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.NewTypes", name: "Name", newName: "Names");
        }
    }
}
