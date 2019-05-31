namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tese : DbMigration
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
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Value = c.Single(nullable: false),
                        quantity = c.Double(nullable: false),
                        MeasureID = c.Int(nullable: false),
                        ProductTypeID = c.Int(nullable: false),
                        Sales_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Measure", t => t.MeasureID, cascadeDelete: true)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sales_ID)
                .Index(t => t.MeasureID)
                .Index(t => t.ProductTypeID)
                .Index(t => t.Sales_ID);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsPending = c.Boolean(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TotalValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Sales_ID", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Product", "ProductTypeID", "dbo.ProductType");
            DropForeignKey("dbo.Product", "MeasureID", "dbo.Measure");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.Product", new[] { "Sales_ID" });
            DropIndex("dbo.Product", new[] { "ProductTypeID" });
            DropIndex("dbo.Product", new[] { "MeasureID" });
            DropTable("dbo.Sales");
            DropTable("dbo.ProductType");
            DropTable("dbo.Product");
            DropTable("dbo.Measure");
            DropTable("dbo.Customer");
        }
    }
}
