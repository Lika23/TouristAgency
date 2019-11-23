namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookTourModels", newName: "BookedTours");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BookedTours", newName: "BookTourModels");
        }
    }
}
