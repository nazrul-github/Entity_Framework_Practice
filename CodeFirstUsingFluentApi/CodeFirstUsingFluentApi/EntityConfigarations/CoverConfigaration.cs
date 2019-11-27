using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstUsingFluentApi.EntityConfigarations
{
    public class CoverConfigaration : EntityTypeConfiguration<Cover>
    {
        public CoverConfigaration()
        {
            HasKey(c => c.CoverId);
            Property(c => c.CoverId)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
