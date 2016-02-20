namespace TheSchool.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheSchool.Common;
    using TheSchool.Data.Common.Models;

    public class Mark : BaseModel<int>
    {
        [Required]
        [Range(GlobalConstants.MinMark, GlobalConstants.MaxMark)]
        public int Value { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        public int DisciplineId { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual Discipline Discipline { get; set; }

        [Required]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
    }
}