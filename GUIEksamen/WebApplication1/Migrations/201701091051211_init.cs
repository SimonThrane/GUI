namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Menu = c.String(),
                        Time = c.DateTime(nullable: false),
                        FoodClub_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DayId)
                .ForeignKey("dbo.FoodClubs", t => t.FoodClub_Id)
                .Index(t => t.FoodClub_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodClub_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodClubs", t => t.FoodClub_Id)
                .Index(t => t.FoodClub_Id);
            
            CreateTable(
                "dbo.FoodClubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberDays",
                c => new
                    {
                        Member_Id = c.Int(nullable: false),
                        Day_DayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_Id, t.Day_DayId })
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.Day_DayId, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.Day_DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "FoodClub_Id", "dbo.FoodClubs");
            DropForeignKey("dbo.Days", "FoodClub_Id", "dbo.FoodClubs");
            DropForeignKey("dbo.MemberDays", "Day_DayId", "dbo.Days");
            DropForeignKey("dbo.MemberDays", "Member_Id", "dbo.Members");
            DropIndex("dbo.MemberDays", new[] { "Day_DayId" });
            DropIndex("dbo.MemberDays", new[] { "Member_Id" });
            DropIndex("dbo.Members", new[] { "FoodClub_Id" });
            DropIndex("dbo.Days", new[] { "FoodClub_Id" });
            DropTable("dbo.MemberDays");
            DropTable("dbo.FoodClubs");
            DropTable("dbo.Members");
            DropTable("dbo.Days");
        }
    }
}
