namespace MVCAplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAdds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Sales_ID1", "dbo.Sales");
            DropIndex("dbo.Product", new[] { "Sales_ID1" });
            DropColumn("dbo.Product", "Sales_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Sales_ID1", c => c.Int());
            CreateIndex("dbo.Product", "Sales_ID1");
            AddForeignKey("dbo.Product", "Sales_ID1", "dbo.Sales", "ID");
        }
    }
}
