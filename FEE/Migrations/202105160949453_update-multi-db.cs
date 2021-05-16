namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemultidb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Alias");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TecherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Position = c.String(),
                        WorkPlace = c.String(),
                        WebSite = c.String(),
                        Content = c.String(),
                        Img = c.String(),
                        DepartmentId = c.String(),
                    })
                .PrimaryKey(t => t.TecherId);
            
            AddColumn("dbo.Categories", "Alias", c => c.String(maxLength: 256));
        }
    }
}
