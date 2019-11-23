namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookTourModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.BookTourModels", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.BookTourModels", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookTourModels", "Number", c => c.String());
            AlterColumn("dbo.BookTourModels", "Email", c => c.String());
            AlterColumn("dbo.BookTourModels", "Name", c => c.String());
        }
    }
}
