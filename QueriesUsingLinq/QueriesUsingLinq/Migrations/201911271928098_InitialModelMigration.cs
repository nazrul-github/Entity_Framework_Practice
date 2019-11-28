namespace QueriesUsingLinq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        CoverId = c.Int(nullable: false),
                        CoverName = c.String(),
                    })
                .PrimaryKey(t => t.CoverId)
                .ForeignKey("dbo.Course", t => t.CoverId)
                .Index(t => t.CoverId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FullPrice = c.Single(nullable: false),
                        Level = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        CoverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.Covers", "CoverId", "dbo.Course");
            DropIndex("dbo.Course", new[] { "AuthorId" });
            DropIndex("dbo.Covers", new[] { "CoverId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Author");
            DropTable("dbo.Course");
            DropTable("dbo.Covers");
        }
    }
}
