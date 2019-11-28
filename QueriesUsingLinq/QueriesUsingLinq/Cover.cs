namespace QueriesUsingLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cover
    {
        public int CoverId { get; set; }

        public string CoverName { get; set; }

        public virtual Course Course { get; set; }
    }
}
