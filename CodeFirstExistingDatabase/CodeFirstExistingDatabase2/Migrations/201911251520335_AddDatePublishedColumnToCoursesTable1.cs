namespace CodeFirstExistingDatabase2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePublishedColumnToCoursesTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses","Title",c=>c.String(nullable:false));
            DropColumn("dbo.Courses","Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "Name");
        }
    }
}
