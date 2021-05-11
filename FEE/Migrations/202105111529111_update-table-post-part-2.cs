namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablepostpart2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "MenuId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "DepartmentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DepartmentId", c => c.String());
            AlterColumn("dbo.Posts", "MenuId", c => c.String());
            AlterColumn("dbo.Posts", "CategoryId", c => c.String(maxLength: 128));
        }
    }
}
