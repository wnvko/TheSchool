namespace TheSchool.Web.Areas.Teacher.ViewModels
{
    using System.Collections.Generic;
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;
    using TheSchool.Web.ViewModels.Marks;

    public class StudentWithMarksInputModel : IMapFrom<Student>
    {
        public string Id { get; set; }

        public virtual ICollection<MarksInputModel> Marks { get; set; }
    }
}