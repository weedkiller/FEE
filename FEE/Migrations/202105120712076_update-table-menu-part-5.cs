namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablemenupart5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "URL", c => c.String());
            AddColumn("dbo.Menus", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Menus", "PostId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "PostId");
            DropColumn("dbo.Menus", "DisplayOrder");
            DropColumn("dbo.Menus", "URL");
        }
    }
}
