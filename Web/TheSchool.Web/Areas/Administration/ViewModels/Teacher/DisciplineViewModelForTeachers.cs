namespace TheSchool.Web.Areas.Administration.ViewModels.Teacher
{
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class DisciplineViewModelForTeachers : IMapFrom<Discipline>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
