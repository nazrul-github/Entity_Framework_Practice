namespace QueriesUsingLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Course
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

      
        public string Description { get; set; }

        public float FullPrice { get; set; }

        public int Level { get; set; }

        public int AuthorId { get; set; }

        public int CoverId { get; set; }

        public virtual Cover Cover { get; set; }

        public virtual tbl_Author tbl_Author { get; set; }
    }
}
