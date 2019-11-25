namespace CodeFirstExistingDatabase2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Courses", "Name", "Title");
        }

        public override void Down()
        {
            RenameColumn("dbo.Courses", "Title", "Title");
        }
    }
}
