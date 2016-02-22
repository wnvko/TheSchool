namespace TheSchool.Web.Areas.Administration.ViewModels.Teacher
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using TheSchool.Data.Models;

    public class TeacherViewModel : IMapFrom<Teacher>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public virtual ICollection<DivisionViewModelForTeachers> Divisions { get; set; }

        [UIHint("DivisionNameDropDown")]
        public virtual ICollection<DisciplineViewModelForTeachers> Disciplines { get; set; }

        public virtual ICollection<MarkViewModelForTeachers> Marks { get; set; }
    }
}
