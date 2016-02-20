namespace TheSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Discipline : BaseModel<int>
    {
        private ICollection<Division> divisions;
        private ICollection<Teacher> teachers;
        private ICollection<Mark> marks;

        public Discipline()
        {
            this.divisions = new HashSet<Division>();
            this.teachers = new HashSet<Teacher>();
            this.marks = new HashSet<Mark>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Division> Divisions
        {
            get { return this.divisions; }
            set { this.divisions = value; }
        }

        public virtual ICollection<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public virtual ICollection<Mark> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}
