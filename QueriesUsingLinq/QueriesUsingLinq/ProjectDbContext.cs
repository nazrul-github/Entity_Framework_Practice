using QueriesUsingLinq.EntityConfigaration;

namespace QueriesUsingLinq
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

        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Configurations.Add(new CourseConfigaration());
        }
    }
}
