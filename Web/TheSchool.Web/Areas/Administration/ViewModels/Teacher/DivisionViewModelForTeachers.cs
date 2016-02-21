namespace TheSchool.Web.Areas.Administration.ViewModels.Teacher
{
    using Infrastructure.Mapping;
    using TheSchool.Data.Models;

    public class DivisionViewModelForTeachers : IMapFrom<Division>
    {
        public int Id { get; set; }

        public int Grade { get; set; }

        public string Name { get; set; }
    }
}
