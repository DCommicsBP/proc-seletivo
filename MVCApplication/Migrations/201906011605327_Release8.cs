namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Release8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Releases", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Releases", "RelaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Releases", "RelaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Releases", "ReleaseDate");
        }
    }
}
