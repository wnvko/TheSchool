namespace TheSchool.Web.Areas.Teacher.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels;
    using Web.Controllers;
    using Web.ViewModels.Students;

    public class StudentController : BaseController
    {
        private readonly IStudentsService students;

        public StudentController(IStudentsService students)
        {
            this.students = students;
        }

        public ActionResult Details(string id)
        {
            var student = this.students
                .All()
                .Where(s => s.Id == id)
                .To<StudentViewModel>()
                .ToList();

            var marks = new MarksDropDownListModel();

            var viewModel = new StudentDetailsViewModel()
            {
                Students = student,
                Marks = marks.Marks,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(IList<string> marks)
        {
            return null;
        }
    }
}