namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablemenu4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Menus", new[] { "Name" });
            AlterColumn("dbo.Menus", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "UpdateDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Menus", "Name", unique: true);
        }
    }
}
