namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Release : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RelaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Value = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Releases");
        }
    }
}
