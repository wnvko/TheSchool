namespace TheSchool.Web.Areas.Teacher.ViewModels
{
    using System.Collections.Generic;

    public class TutorClassIndexViewModel
    {
        public string ClassName { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}