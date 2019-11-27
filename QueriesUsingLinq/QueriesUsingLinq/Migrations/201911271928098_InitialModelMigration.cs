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
                .ForeignKey("dbo.tbl_Course", t => t.CoverId)
                .Index(t => t.CoverId);
            
            CreateTable(
                "dbo.tbl_Course",
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
                .ForeignKey("dbo.tbl_Author", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.tbl_Author",
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
            DropForeignKey("dbo.tbl_Course", "AuthorId", "dbo.tbl_Author");
            DropForeignKey("dbo.Covers", "CoverId", "dbo.tbl_Course");
            DropIndex("dbo.tbl_Course", new[] { "AuthorId" });
            DropIndex("dbo.Covers", new[] { "CoverId" });
            DropTable("dbo.Tags");
            DropTable("dbo.tbl_Author");
            DropTable("dbo.tbl_Course");
            DropTable("dbo.Covers");
        }
    }
}
