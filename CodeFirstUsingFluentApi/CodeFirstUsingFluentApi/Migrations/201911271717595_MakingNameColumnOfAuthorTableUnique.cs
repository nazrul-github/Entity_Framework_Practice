namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingNameColumnOfAuthorTableUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Authors", "Name", name: "Index1");
            CreateIndex("dbo.Authors", "Name", unique: true, name: "Index2");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", "Index2");
            DropIndex("dbo.Authors", "Index1");
        }
    }
}
