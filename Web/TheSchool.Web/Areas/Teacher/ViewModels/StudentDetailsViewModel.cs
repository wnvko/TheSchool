namespace TheSchool.Web.Areas.Teacher.ViewModels
{
    using System.Collections.Generic;
    using Web.ViewModels.Students;

    public class StudentDetailsViewModel
    {
        public IList<StudentViewModel> Students { get; set; }

        public IList<int> Marks { get; set; }
    }
}
