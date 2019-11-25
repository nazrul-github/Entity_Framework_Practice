namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_propety_body : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Body");
        }
    }
}
