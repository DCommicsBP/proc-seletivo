namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productsModify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Measure", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductType");
            DropColumn("dbo.Product", "Measure");
        }
    }
}
