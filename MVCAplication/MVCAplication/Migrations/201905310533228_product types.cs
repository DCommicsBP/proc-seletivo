namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "MeasureID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductTypeID", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "Measure");
            DropColumn("dbo.Product", "ProductType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductType", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Measure", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ProductTypeID");
            DropColumn("dbo.Product", "MeasureID");
        }
    }
}
