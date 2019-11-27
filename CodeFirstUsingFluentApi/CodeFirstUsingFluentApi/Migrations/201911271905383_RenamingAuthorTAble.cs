namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingAuthorTAble : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authors", newName: "tbl_Author");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tbl_Author", newName: "Authors");
        }
    }
}
