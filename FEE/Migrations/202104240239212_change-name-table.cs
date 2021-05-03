namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenametable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Permission", newName: "Permissions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Permissions", newName: "Permission");
        }
    }
}
