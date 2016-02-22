namespace TheSchool.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
    using ViewModels.News;
    using ViewModels.Students;

    public class HomeController : BaseController
    {
        private readonly IStudentsService students;
        private readonly INewsService news;

        public HomeController(IStudentsService students, INewsService news)
        {
            this.students = students;
            this.news = news;
        }

        public ActionResult Index()
        {
            var topTenStudentsByMarks = this.students
                .GetTopTenByMarks()
                .To<StudentViewModel>()
                .ToList();

            var latestTenNews = this.news
                .GetLatestTenNews()
                .To<NewsViewModel>()
                .ToList();

            var viewModel = new HomeIndexViewModel()
            {
                Students = topTenStudentsByMarks,
                News = latestTenNews,
            };

            return this.View(viewModel);
        }
    }
}
