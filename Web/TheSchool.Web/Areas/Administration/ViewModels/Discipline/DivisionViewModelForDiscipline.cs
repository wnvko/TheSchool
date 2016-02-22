namespace TheSchool.Web.Areas.Administration.ViewModels.Discipline
{
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class DivisionViewModelForDiscipline : IMapFrom<Division>
    {
        public int Id { get; set; }

        public int Grade { get; set; }

        public string Name { get; set; }
    }
}
