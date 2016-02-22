namespace TheSchool.Web.Areas.Administration.ViewModels.Discipline
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MarksViewModelForDisciplines : IMapFrom<Mark>
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string StudentId { get; set; }
    }
}
