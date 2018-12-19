namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Tour_Id", c => c.Int());
            CreateIndex("dbo.Pictures", "Tour_Id");
            AddForeignKey("dbo.Pictures", "Tour_Id", "dbo.Tours", "Id");
            DropColumn("dbo.Countries", "Url");
            DropColumn("dbo.Pictures", "TourId");
            DropColumn("dbo.Tours", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "Url", c => c.String());
            AddColumn("dbo.Pictures", "TourId", c => c.Int(nullable: false));
            AddColumn("dbo.Countries", "Url", c => c.String());
            DropForeignKey("dbo.Pictures", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.Pictures", new[] { "Tour_Id" });
            DropColumn("dbo.Pictures", "Tour_Id");
        }
    }
}
