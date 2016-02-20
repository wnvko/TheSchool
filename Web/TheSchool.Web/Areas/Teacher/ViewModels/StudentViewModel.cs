namespace TheSchool.Web.Areas.Teacher.ViewModels
{
    using System.Collections.Generic;
    using TheSchool.Data.Models;
    using TheSchool.Web.Infrastructure.Mapping;

    public class StudentViewModel : IMapFrom<Student>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }


        public virtual ICollection<Mark> Marks { get; set; }
    }
}