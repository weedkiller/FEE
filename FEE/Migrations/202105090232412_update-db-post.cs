namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsShow");
        }
    }
}
