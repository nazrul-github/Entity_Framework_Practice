namespace QueriesUsingLinq
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Author
    {
       
        public tbl_Author()
        {
            tbl_Course = new HashSet<tbl_Course>();
        }

        public int Id { get; set; }
      
        public string Name { get; set; }
    
        public virtual ICollection<tbl_Course> tbl_Course { get; set; }
    }
}
