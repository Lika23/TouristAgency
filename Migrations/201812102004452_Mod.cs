namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "History", c => c.String());
            AddColumn("dbo.Countries", "Attractions", c => c.String());
            AddColumn("dbo.Countries", "Leisure", c => c.String());
            AddColumn("dbo.Countries", "Tip", c => c.String());
            DropColumn("dbo.Countries", "Description");
            DropColumn("dbo.Countries", "Climate");
            DropColumn("dbo.Countries", "Kitchen");
            DropColumn("dbo.Countries", "Geography");
            DropColumn("dbo.Countries", "Population");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Population", c => c.String());
            AddColumn("dbo.Countries", "Geography", c => c.String());
            AddColumn("dbo.Countries", "Kitchen", c => c.String());
            AddColumn("dbo.Countries", "Climate", c => c.String());
            AddColumn("dbo.Countries", "Description", c => c.String());
            DropColumn("dbo.Countries", "Tip");
            DropColumn("dbo.Countries", "Leisure");
            DropColumn("dbo.Countries", "Attractions");
            DropColumn("dbo.Countries", "History");
        }
    }
}
