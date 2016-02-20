namespace TheSchool.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
    using ViewModels.Students;
    public class HomeController : BaseController
    {
        private readonly IStudentsService students;

        public HomeController(IStudentsService students)
        {
            this.students = students;
        }

        public ActionResult Index()
        {
            var topTenStudentsByMarks = students
                .GetTopTenByMarks()
                .To<StudentViewModel>()
                .ToList();

            var viewModel = new HomeIndexViewModel()
            {
                Students = topTenStudentsByMarks,
            };

            return this.View(viewModel);
        }
    }
}
