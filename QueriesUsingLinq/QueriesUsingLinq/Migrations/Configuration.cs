using System.Collections.Generic;

namespace QueriesUsingLinq.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QueriesUsingLinq.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QueriesUsingLinq.ProjectDbContext context)
        {
            #region Add Tags

            var tags = new Dictionary<string, Tag>
            {
                {"C#", new Tag(){Id = 1,Name = "C#"}},
                {"angularJs",new Tag(){Id = 2,Name = "angularJs"}},
                {"javascript",new Tag() {Id = 3,Name = "javascript"}},
                {"nodeJs",new Tag() {Id = 4,Name = "nodeJs"}},
                {"oop",new Tag() {Id = 5,Name = "oop"}},
                {"linq", new Tag() {Id = 6,Name = "linq"}}
            };
            foreach (var tag in tags.Values)
            {
                context.Tags.AddOrUpdate(t=>t.Id,tag);
            }

            #endregion
        }
    }
}
