namespace TheSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheSchool.Data.Common.Models;

    public class Division : BaseModel<int>
    {
        private ICollection<Discipline> disciplines;
        private ICollection<Student> students;

        public Division()
        {
            this.disciplines = new HashSet<Discipline>();
            this.students = new HashSet<Student>();
        }

        [Required]
        public int Grade { get; set; }

        [Required]
        public string Name { get; set; }

        public string ClassTutorId { get; set; }

        [ForeignKey("ClassTutorId")]
        public virtual Teacher ClassTutor { get; set; }

        public virtual ICollection<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
