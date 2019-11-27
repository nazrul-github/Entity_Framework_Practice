namespace CodeFirstUsingFluentApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIndexInAuthorTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "asdfasdf",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: Index1 }{ Name: Index2, IsUnique: True }", newValue: null)
                    },
                }));
            CreateIndex("dbo.Authors", "Name", name: "Index1");
            CreateIndex("dbo.Authors", "Name", unique: true, name: "Index2");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", "Index2");
            DropIndex("dbo.Authors", "Index1");
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "asdfasdf",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: Index1 }{ Name: Index2, IsUnique: True }")
                    },
                }));
        }
    }
}
