namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donedbpart2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ReplyId = c.String(maxLength: 4000),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            DropColumn("dbo.Menus", "PostId");
            DropColumn("dbo.Slides", "Url");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostId = c.String(maxLength: 128),
                        ReplyId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        UserName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CommentId);
            
            AddColumn("dbo.Slides", "Url", c => c.String());
            AddColumn("dbo.Menus", "PostId", c => c.Int());
            DropTable("dbo.Contacts");
        }
    }
}
