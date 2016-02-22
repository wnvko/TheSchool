namespace TheSchool.Web.Areas.Administration.ViewModels.Discipline
{
    using Infrastructure.Mapping;
    using TheSchool.Data.Models;

    public class TeachersViewModelForDiscipline : IMapFrom<Teacher>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
