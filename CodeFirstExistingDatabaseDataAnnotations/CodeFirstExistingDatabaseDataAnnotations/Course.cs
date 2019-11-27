namespace CodeFirstExistingDatabaseDataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public partial class Course
    {
        public int Id { get; set; }
       [Required]
       [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        
        public float FullPrice { get; set; }

        public int Level { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
