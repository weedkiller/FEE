namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablemenu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "ParentId", c => c.Int(nullable: false));
        }
    }
}
