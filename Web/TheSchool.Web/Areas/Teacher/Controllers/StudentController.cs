namespace TheSchool.Web.Areas.Teacher.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels;
    using Web.Controllers;
    using Web.ViewModels.Students;

    [Authorize(Roles = GlobalConstants.TeacherRoleName)]
    public class StudentController : BaseController
    {
        private readonly IStudentsService students;

        public StudentController(IStudentsService students)
        {
            this.students = students;
        }

        public ActionResult Details(string id)
        {
            var viewModel = this.students
                .All()
                .Where(s => s.Id == id)
                .To<StudentViewModel>()
                .FirstOrDefault();

            if (viewModel == null)
            {
                this.RedirectToAction("Index", "TutorClass");
            }

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StudentWithMarksInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction("Index", "Home");
            }

            var student = this.students.GetById(model.Id);
            if (student == null)
            {
                this.RedirectToAction("Index", "Home");
            }

            foreach (var mark in model.Marks)
            {
                if (mark.Value.HasValue)
                {
                    student.Marks.FirstOrDefault(m => m.Id == mark.Id).Value = (int)mark.Value;
                }
            }

            this.students.Save();
            return this.RedirectToAction("Details", new { student.Id });
        }
    }
}
