namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Days", "Time", c => c.DateTime(nullable: false));
        }
    }
}
