namespace Assesment.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredActive : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Active", c => c.Boolean());
        }
    }
}
