namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CPF = c.String(),
                        RG = c.String(),
                        Debtor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Measure",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Value = c.Single(nullable: false),
                        quantity = c.Double(nullable: false),
                        Sales_ID = c.Int(),
                        Sales_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sales", t => t.Sales_ID)
                .ForeignKey("dbo.Sales", t => t.Sales_ID1)
                .Index(t => t.Sales_ID)
                .Index(t => t.Sales_ID1);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsPending = c.Boolean(nullable: false),
                        Customer = c.Int(nullable: false),
                        TotalValue = c.Double(nullable: false),
                        Cust_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Cust_ID)
                .Index(t => t.Cust_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Sales_ID1", "dbo.Sales");
            DropForeignKey("dbo.Product", "Sales_ID", "dbo.Sales");
            DropForeignKey("dbo.Sales", "Cust_ID", "dbo.Customer");
            DropForeignKey("dbo.ProductType", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Measure", "Product_ID", "dbo.Product");
            DropIndex("dbo.Sales", new[] { "Cust_ID" });
            DropIndex("dbo.ProductType", new[] { "Product_ID" });
            DropIndex("dbo.Product", new[] { "Sales_ID1" });
            DropIndex("dbo.Product", new[] { "Sales_ID" });
            DropIndex("dbo.Measure", new[] { "Product_ID" });
            DropTable("dbo.Sales");
            DropTable("dbo.ProductType");
            DropTable("dbo.Product");
            DropTable("dbo.Measure");
            DropTable("dbo.Customer");
        }
    }
}
