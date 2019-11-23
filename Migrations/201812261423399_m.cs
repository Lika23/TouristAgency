namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookTourModels", "TourId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookTourModels", "TourId");
        }
    }
}
