namespace TheSchool.Web.Areas.Administration.ViewModels.Teacher
{
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using TheSchool.Data.Models;

    public class TeacherViewModel : IMapFrom<Teacher>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        //public virtual ICollection<DivisionViewModelForTeachers> Divisions { get; set; }

        //public virtual ICollection<DisciplineViewModelForTeachers> Disciplines { get; set; }

        //public virtual ICollection<Mark> Marks { get; set; }
    }
}
