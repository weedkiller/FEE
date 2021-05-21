namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Status");
            DropColumn("dbo.Departments", "Status");
            DropColumn("dbo.Categories", "Status");
        }
    }
}
