namespace TheSchool.Web.Areas.Administration.ViewModels.Teacher
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MarkViewModelForTeachers : IMapFrom<Mark>
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string StudentId { get; set; }
    }
}
