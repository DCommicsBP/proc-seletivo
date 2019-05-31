namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodateAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "Cust_ID", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "Cust_ID" });
            RenameColumn(table: "dbo.Sales", name: "Cust_ID", newName: "CustomerID");
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "CustomerID");
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customer", "ID", cascadeDelete: true);
            DropColumn("dbo.Sales", "Customer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Customer", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            AlterColumn("dbo.Sales", "CustomerID", c => c.Int());
            RenameColumn(table: "dbo.Sales", name: "CustomerID", newName: "Cust_ID");
            CreateIndex("dbo.Sales", "Cust_ID");
            AddForeignKey("dbo.Sales", "Cust_ID", "dbo.Customer", "ID");
        }
    }
}
