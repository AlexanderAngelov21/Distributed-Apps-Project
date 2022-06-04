namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 30),
                        CountryOfOrigin = c.String(nullable: false, maxLength: 50),
                        FoundedIn = c.Short(nullable: false),
                        AddedOn = c.DateTime(),
                        AddedFrom = c.String(nullable: false, maxLength: 50),
                        LowestModelPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motorcycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 80),
                        Condition = c.String(nullable: false, maxLength: 10),
                        Color = c.String(nullable: false, maxLength: 50),
                        Power = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManifactureDate = c.DateTime(nullable: false),
                        Details = c.String(maxLength: 70),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotorcycleID = c.Int(nullable: false),
                        ClientFirstName = c.String(nullable: false),
                        ClientLastName = c.String(nullable: false),
                        SellerName = c.String(),
                        SaleDate = c.DateTime(),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Motorcycles", t => t.MotorcycleID, cascadeDelete: true)
                .Index(t => t.MotorcycleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "MotorcycleID", "dbo.Motorcycles");
            DropForeignKey("dbo.Motorcycles", "BrandID", "dbo.Brands");
            DropIndex("dbo.Sales", new[] { "MotorcycleID" });
            DropIndex("dbo.Motorcycles", new[] { "BrandID" });
            DropTable("dbo.Sales");
            DropTable("dbo.Motorcycles");
            DropTable("dbo.Brands");
        }
    }
}
