namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablemenu2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "PostId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "PostId", c => c.Int(nullable: false));
        }
    }
}
