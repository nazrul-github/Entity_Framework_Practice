using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Utilities;
using CodeFirstUsingFluentApi.EntityConfigarations;

namespace CodeFirstUsingFluentApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
            : base("name=ProjectDbContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfigaration());
            modelBuilder.Configurations.Add(new AuthorConfigaration());
            modelBuilder.Configurations.Add(new CoverConfigaration());
            modelBuilder.Configurations.Add(new TagConfigaration());
        }
    }
}
