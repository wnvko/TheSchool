namespace TheSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Teacher : ApplicationUser
    {
        private ICollection<Discipline> disciplines;
        private ICollection<Mark> marks;
        private ICollection<Division> divisions;

        public Teacher()
        {
            this.disciplines = new HashSet<Discipline>();
            this.marks = new HashSet<Mark>();
            this.divisions = new HashSet<Division>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        public virtual ICollection< Division> Divisions
        {
            get { return this.divisions; }
            set { this.divisions = value; }
        }

        public virtual ICollection<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }

        public virtual ICollection<Mark> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}
