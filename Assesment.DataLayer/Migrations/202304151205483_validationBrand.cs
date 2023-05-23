namespace Assesment.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationBrand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String());
        }
    }
}
