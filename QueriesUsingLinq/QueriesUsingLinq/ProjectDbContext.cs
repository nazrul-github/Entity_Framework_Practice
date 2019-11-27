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
        public virtual DbSet<tbl_Author> tbl_Author { get; set; }
        public virtual DbSet<tbl_Course> tbl_Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Author>()
                .HasMany(e => e.tbl_Course)
                .WithRequired(e => e.tbl_Author)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Course>()
                .HasOptional(e => e.Cover)
                .WithRequired(e => e.tbl_Course);
        }
    }
}
