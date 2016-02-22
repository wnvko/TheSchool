namespace TheSchool.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.News;

    public class NewsController : Controller
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        public ActionResult Details(int id)
        {
            var news = this.news
                .All()
                .Where(n => n.Id == id)
                .To<NewsViewModel>()
                .FirstOrDefault();
            return this.View(news);
        }
    }
}