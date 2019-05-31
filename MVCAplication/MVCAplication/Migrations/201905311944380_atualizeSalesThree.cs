namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizeSalesThree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Sales_ID", "dbo.Sales");
            DropIndex("dbo.Product", new[] { "Sales_ID" });
            CreateTable(
                "dbo.ProductSales",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Sales_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Sales_ID })
                .ForeignKey("dbo.Product", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sales_ID, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Sales_ID);
            
            DropColumn("dbo.Product", "Sales_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Sales_ID", c => c.Int());
            DropForeignKey("dbo.ProductSales", "Sales_ID", "dbo.Sales");
            DropForeignKey("dbo.ProductSales", "Product_ID", "dbo.Product");
            DropIndex("dbo.ProductSales", new[] { "Sales_ID" });
            DropIndex("dbo.ProductSales", new[] { "Product_ID" });
            DropTable("dbo.ProductSales");
            CreateIndex("dbo.Product", "Sales_ID");
            AddForeignKey("dbo.Product", "Sales_ID", "dbo.Sales", "ID");
        }
    }
}
