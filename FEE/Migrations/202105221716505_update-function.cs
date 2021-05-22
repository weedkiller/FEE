namespace FEE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefunction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Functions", "Icons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Functions", "Icons", c => c.String());
        }
    }
}
