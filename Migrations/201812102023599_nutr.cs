namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nutr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "Nutrition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "Nutrition");
        }
    }
}
