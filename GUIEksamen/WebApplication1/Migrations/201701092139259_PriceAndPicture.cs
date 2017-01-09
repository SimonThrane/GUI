namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceAndPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Days", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Days", "Picture");
            DropColumn("dbo.Days", "Price");
        }
    }
}
