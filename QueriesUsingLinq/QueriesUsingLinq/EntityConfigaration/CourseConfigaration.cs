using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QueriesUsingLinq.EntityConfigaration
{
    class CourseConfigaration : EntityTypeConfiguration<Course>
    {
        public CourseConfigaration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).HasMaxLength(100);
            Property(c => c.Name).IsRequired();
            Property(c => c.Description).IsRequired();
            Property(c => c.Description).HasMaxLength(2000);
            Property(c => c.FullPrice).IsRequired();
            Property(c => c.Level).IsRequired();

            HasRequired(c => c.Author).WithMany(a => a.Courses).HasForeignKey(c => c.AuthorId);
            HasMany(c => c.Tags).WithMany(t => t.Courses).Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");
            });
            HasRequired(c => c.Cover).WithRequiredPrincipal(cov => cov.Course);
        }
    }
}
