using System.Collections.Generic;

namespace CodeFirstExistingDatabase2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstExistingDatabase2.PlutonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstExistingDatabase2.PlutonContext context)
        {
            context.Authors.AddOrUpdate(a=>a.Name,new Author{Name = "Author 1",Courses = new List<Course>
            {
                new Course{Name = "Course for author 1",Description = "Description"}
            }});
        }
    }
}
