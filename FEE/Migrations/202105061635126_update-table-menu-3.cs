namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablemenu3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "UpdateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Menus", "URL");
            DropColumn("dbo.Menus", "DisplayOrder");
            DropColumn("dbo.Menus", "Content");
            DropColumn("dbo.Menus", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "PostId", c => c.Int());
            AddColumn("dbo.Menus", "Content", c => c.String());
            AddColumn("dbo.Menus", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Menus", "URL", c => c.String());
            DropColumn("dbo.Menus", "UpdateDate");
        }
    }
}
