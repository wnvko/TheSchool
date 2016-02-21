namespace TheSchool.Web.Areas.Teacher.ViewModels
{
    using System.Collections.Generic;
    using Web.ViewModels.Students;
    public class TutorClassIndexViewModel
    {
        public int Page { get; set; }

        public int Pages { get; set; }

        public string ClassName { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}