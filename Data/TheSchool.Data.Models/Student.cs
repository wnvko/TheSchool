namespace TheSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student : ApplicationUser
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public int DivisionId { get; set; }

        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }

        public virtual ICollection<Mark> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}
