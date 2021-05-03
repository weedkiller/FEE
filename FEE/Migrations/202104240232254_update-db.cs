namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Permission");
            AlterColumn("dbo.Permission", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Permission", new[] { "FunctionId", "RoleId", "CommandId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Permission");
            AlterColumn("dbo.Permission", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Permission", new[] { "FunctionId", "RoleId", "CommandId" });
        }
    }
}
