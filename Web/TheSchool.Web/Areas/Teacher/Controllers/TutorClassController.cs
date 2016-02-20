namespace TheSchool.Web.Areas.Teacher.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels;

    [Authorize(Roles = GlobalConstants.TeacherRoleName)]
    public class TutorClassController : Controller
    {
        private readonly IStudentsService students;

        public TutorClassController(IStudentsService students)
        {
            this.students = students;
        }

        public ActionResult Index()
        {
            var myStudents = this.students
                .GetByClassTutorId(this.User.Identity.GetUserId())
                .To<StudentViewModel>()
                .ToList();

            var viewModel = new TutorClassIndexViewModel()
            {
                Students = myStudents,
                ClassName = "Vtori be",
            };
            return this.View(viewModel);
        }
    }
}