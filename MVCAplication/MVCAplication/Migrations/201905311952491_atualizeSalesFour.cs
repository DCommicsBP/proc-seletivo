namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizeSalesFour : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Measure", newName: "Measures");
            RenameTable(name: "dbo.ProductType", newName: "ProductTypes");
            RenameColumn(table: "dbo.ProductSales", name: "Product_ID", newName: "SalesRefId");
            RenameColumn(table: "dbo.ProductSales", name: "Sales_ID", newName: "ProductRefId");
            RenameIndex(table: "dbo.ProductSales", name: "IX_Product_ID", newName: "IX_SalesRefId");
            RenameIndex(table: "dbo.ProductSales", name: "IX_Sales_ID", newName: "IX_ProductRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductSales", name: "IX_ProductRefId", newName: "IX_Sales_ID");
            RenameIndex(table: "dbo.ProductSales", name: "IX_SalesRefId", newName: "IX_Product_ID");
            RenameColumn(table: "dbo.ProductSales", name: "ProductRefId", newName: "Sales_ID");
            RenameColumn(table: "dbo.ProductSales", name: "SalesRefId", newName: "Product_ID");
            RenameTable(name: "dbo.ProductTypes", newName: "ProductType");
            RenameTable(name: "dbo.Measures", newName: "Measure");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Customers", newName: "Customer");
        }
    }
}
