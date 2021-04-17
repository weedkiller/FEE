namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.CommandInFunctions",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        FunctionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommandId, t.FunctionId });
            
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CommandId)
                .Index(t => t.Name, unique: true);
            
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
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Url = c.String(),
                        SortOrder = c.Int(),
                        ParentId = c.String(maxLength: 128),
                        Icons = c.String(),
                    })
                .PrimaryKey(t => t.FunctionId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        URL = c.String(),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        CommandId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FunctionId, t.RoleId, t.CommandId });
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        CategoryId = c.String(maxLength: 128),
                        MenuId = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        Img = c.String(),
                        MoreImgs = c.String(),
                        DepartmentId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        SlideId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Img = c.String(),
                        Url = c.String(),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        DepartmentId = c.String(),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SlideId);
            
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
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreateBy = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebInfo",
                c => new
                    {
                        WebInfoId = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Facebook = c.String(),
                        Youtube = c.String(),
                        Zalo = c.String(),
                    })
                .PrimaryKey(t => t.WebInfoId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "Name" });
            DropIndex("dbo.Menus", new[] { "Name" });
            DropIndex("dbo.Functions", new[] { "Name" });
            DropIndex("dbo.Commands", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.WebInfo");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Teachers");
            DropTable("dbo.Slides");
            DropTable("dbo.Roles");
            DropTable("dbo.Posts");
            DropTable("dbo.Permission");
            DropTable("dbo.Menus");
            DropTable("dbo.Functions");
            DropTable("dbo.Departments");
            DropTable("dbo.Comments");
            DropTable("dbo.Commands");
            DropTable("dbo.CommandInFunctions");
            DropTable("dbo.Categories");
        }
    }
}
