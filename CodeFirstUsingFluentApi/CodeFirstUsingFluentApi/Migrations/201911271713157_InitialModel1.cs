namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", "Index1");
            RenameIndex(table: "dbo.Authors", name: "Index2", newName: "IX_Name");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Authors", name: "IX_Name", newName: "Index2");
            CreateIndex("dbo.Authors", "Name", name: "Index1");
        }
    }
}
