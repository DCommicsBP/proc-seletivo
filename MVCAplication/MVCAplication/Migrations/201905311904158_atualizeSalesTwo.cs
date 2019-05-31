namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizeSalesTwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int());
            CreateIndex("dbo.Sales", "CustomerID");
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customer", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "CustomerID");
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customer", "ID", cascadeDelete: true);
        }
    }
}
