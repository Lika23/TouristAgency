namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "City", c => c.String());
            AlterColumn("dbo.Tours", "Hotel", c => c.String());
            AlterColumn("dbo.Tours", "Nutrition", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "Nutrition", c => c.String(nullable: false));
            AlterColumn("dbo.Tours", "Hotel", c => c.String(nullable: false));
            AlterColumn("dbo.Tours", "City", c => c.String(nullable: false));
        }
    }
}
