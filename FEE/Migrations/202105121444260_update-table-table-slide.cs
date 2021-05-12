namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabletableslide : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Slides", "Name");
            DropColumn("dbo.Slides", "DisplayOrder");
            DropColumn("dbo.Slides", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Slides", "DepartmentId", c => c.String());
            AddColumn("dbo.Slides", "DisplayOrder", c => c.Int());
            AddColumn("dbo.Slides", "Name", c => c.String());
        }
    }
}
