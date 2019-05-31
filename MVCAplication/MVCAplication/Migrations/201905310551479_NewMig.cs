namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Measure", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.ProductType", "Product_ID", "dbo.Product");
            DropIndex("dbo.Measure", new[] { "Product_ID" });
            DropIndex("dbo.ProductType", new[] { "Product_ID" });
            CreateIndex("dbo.Product", "MeasureID");
            CreateIndex("dbo.Product", "ProductTypeID");
            AddForeignKey("dbo.Product", "MeasureID", "dbo.Measure", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductTypeID", "dbo.ProductType", "ID", cascadeDelete: true);
            DropColumn("dbo.Measure", "Product_ID");
            DropColumn("dbo.ProductType", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductType", "Product_ID", c => c.Int());
            AddColumn("dbo.Measure", "Product_ID", c => c.Int());
            DropForeignKey("dbo.Product", "ProductTypeID", "dbo.ProductType");
            DropForeignKey("dbo.Product", "MeasureID", "dbo.Measure");
            DropIndex("dbo.Product", new[] { "ProductTypeID" });
            DropIndex("dbo.Product", new[] { "MeasureID" });
            CreateIndex("dbo.ProductType", "Product_ID");
            CreateIndex("dbo.Measure", "Product_ID");
            AddForeignKey("dbo.ProductType", "Product_ID", "dbo.Product", "ID");
            AddForeignKey("dbo.Measure", "Product_ID", "dbo.Product", "ID");
        }
    }
}
