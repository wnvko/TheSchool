namespace TheSchool.Web.Areas.Administration.ViewModels.Discipline
{
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using TheSchool.Data.Models;

    public class DisciplineViewModel : IMapFrom<Discipline>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DivisionViewModelForDiscipline> Divisions { get; set; }

        public virtual ICollection<TeachersViewModelForDiscipline> Teachers { get; set; }

        public virtual ICollection<MarksViewModelForDisciplines> Marks { get; set; }
    }
}
