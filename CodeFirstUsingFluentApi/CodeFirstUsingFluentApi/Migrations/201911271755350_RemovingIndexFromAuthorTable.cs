namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingIndexFromAuthorTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", "Index1");
            DropIndex("dbo.Authors", "Index2");
            DropIndex("dbo.Authors", new[] { "Name" });
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "asdfasdf",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: Index1 }{ Name: Index2, IsUnique: True }")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "asdfasdf",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: Index1 }{ Name: Index2, IsUnique: True }", newValue: null)
                    },
                }));
            CreateIndex("dbo.Authors", "Name", unique: true);
            CreateIndex("dbo.Authors", "Name", unique: true, name: "Index2");
            CreateIndex("dbo.Authors", "Name", name: "Index1");
        }
    }
}
