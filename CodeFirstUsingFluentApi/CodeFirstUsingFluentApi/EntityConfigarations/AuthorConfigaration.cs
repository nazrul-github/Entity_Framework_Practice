using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstUsingFluentApi.EntityConfigarations
{
    public class AuthorConfigaration : EntityTypeConfiguration<Author>
    {
        public AuthorConfigaration()
        {
            ToTable("tbl_Author");
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(a => a.Name).HasMaxLength(50);
            HasIndex(a => a.Name).IsUnique(true);

            HasMany(a => a.Courses).WithRequired(c => c.Author).HasForeignKey(c => c.AuthorId).WillCascadeOnDelete(false);
        }
    }
}
