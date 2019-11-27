namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "Index1")
                .Index(t => t.Name, unique: true, name: "Index2");

            CreateTable(
                "dbo.Courses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Description = c.String(maxLength: 255),
                    FullPrice = c.Single(nullable: false),
                    Level = c.Int(nullable: false),
                    AuthorId = c.Int(nullable: false),
                    CoverId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Covers",
                c => new
                {
                    CoverId = c.Int(nullable: false, identity: true),
                    CoverName = c.String(),
                })
                .PrimaryKey(t => t.CoverId)
                .ForeignKey("dbo.Courses", t => t.CoverId)
                .Index(t => t.CoverId);

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CourseTags",
                c => new
                {
                    Course_Id = c.Int(nullable: false),
                    Tag_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Course_Id, t.Tag_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Tag_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.CourseTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Covers", "CoverId", "dbo.Courses");
            DropIndex("dbo.CourseTags", new[] { "Tag_Id" });
            DropIndex("dbo.CourseTags", new[] { "Course_Id" });
            DropIndex("dbo.Covers", new[] { "CoverId" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropIndex("dbo.Authors", "Index2");
            DropIndex("dbo.Authors", "Index1");
            DropTable("dbo.CourseTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
