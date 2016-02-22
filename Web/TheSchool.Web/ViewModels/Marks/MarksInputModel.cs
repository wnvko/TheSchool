namespace TheSchool.Web.ViewModels.Marks
{
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class MarksInputModel : IMapFrom<Mark>
    {
        public int Id { get; set; }

        public int? Value { get; set; }
    }
}
