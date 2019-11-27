namespace CodeFirstExistingDatabaseDataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
