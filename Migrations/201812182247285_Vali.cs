namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vali : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Tours", "Hotel", c => c.String(nullable: false));
            AlterColumn("dbo.Tours", "Nutrition", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "Nutrition", c => c.String());
            AlterColumn("dbo.Tours", "Hotel", c => c.String());
            AlterColumn("dbo.Tours", "City", c => c.String());
        }
    }
}
