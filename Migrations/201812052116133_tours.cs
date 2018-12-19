namespace TouristAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        Night = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        City = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "CountryId", "dbo.Countries");
            DropIndex("dbo.Tours", new[] { "CountryId" });
            DropTable("dbo.Tours");
            DropTable("dbo.Countries");
        }
    }
}
