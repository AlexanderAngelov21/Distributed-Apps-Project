namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustFinalMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "CountryOfOrigin", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Motorcycles", "Model", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Motorcycles", "Condition", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Motorcycles", "Color", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Motorcycles", "Details", c => c.String(maxLength: 60));
            AlterColumn("dbo.Sales", "ClientFirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Sales", "ClientLastName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "ClientLastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Sales", "ClientFirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Motorcycles", "Details", c => c.String(maxLength: 70));
            AlterColumn("dbo.Motorcycles", "Color", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Motorcycles", "Condition", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Motorcycles", "Model", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Brands", "CountryOfOrigin", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
