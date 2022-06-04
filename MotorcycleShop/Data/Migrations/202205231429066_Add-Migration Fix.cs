namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationFix : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Brands", "BrandName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Brands", new[] { "BrandName" });
        }
    }
}
