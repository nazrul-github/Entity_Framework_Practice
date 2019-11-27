using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstUsingFluentApi.EntityConfigarations
{
    public class CourseConfigaration : EntityTypeConfiguration<Course>
    {
        public CourseConfigaration()
        {
            ToTable("tbl_Course");
            HasKey(c => c.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired();
            Property(c => c.Description).HasMaxLength(255);
            Property(c => c.Name).HasMaxLength(255);
            Property(c => c.FullPrice).IsRequired();
            Property(c => c.Level).IsRequired();
            HasMany(c => c.Tags).WithMany(t => t.Courses)
                  .Map(m =>
                  {
                      m.ToTable("CourseTags");
                      m.MapLeftKey("CourseId");
                      m.MapRightKey("TagId");
                  });
            HasRequired(c => c.Cover).WithRequiredPrincipal(cov => cov.Course);
        }
    }
}
