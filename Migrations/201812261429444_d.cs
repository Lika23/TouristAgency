namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BookTourModels", "TourId");
            AddForeignKey("dbo.BookTourModels", "TourId", "dbo.Tours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookTourModels", "TourId", "dbo.Tours");
            DropIndex("dbo.BookTourModels", new[] { "TourId" });
        }
    }
}
