namespace CodeFirstExistingDatabaseDataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Author
    {
        public Author()
        {
            Courses = new HashSet<Course>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

       
        public virtual ICollection<Course> Courses { get; set; }
    }
}
