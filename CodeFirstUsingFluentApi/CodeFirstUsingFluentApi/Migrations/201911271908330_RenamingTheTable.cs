namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingTheTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "tbl_Course");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tbl_Course", newName: "Courses");
        }
    }
}
