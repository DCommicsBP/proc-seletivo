namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Release4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Releases", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Releases", "Status", c => c.Boolean(nullable: false));
        }
    }
}
