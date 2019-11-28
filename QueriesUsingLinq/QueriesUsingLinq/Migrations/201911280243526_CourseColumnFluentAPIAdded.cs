namespace QueriesUsingLinq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseColumnFluentAPIAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Course", "AuthorId", "dbo.tbl_Author");
            RenameTable(name: "dbo.tbl_Course", newName: "Courses");
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Authors (Name)  SELECT Name FROM tbl_Author");
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TagId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TagId);
            
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id");
            DropTable("dbo.tbl_Author");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropTable("dbo.CourseTags");
            DropTable("dbo.Authors");
            AddForeignKey("dbo.tbl_Course", "AuthorId", "dbo.tbl_Author", "Id");
            RenameTable(name: "dbo.Courses", newName: "tbl_Course");
        }
    }
}
