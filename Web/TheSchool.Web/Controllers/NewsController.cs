namespace TheSchool.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.News;

    public class NewsController : Controller
    {
        private const decimal NewsPerPage = 5m;
        private readonly INewsService news;
        private readonly IVotesService votes;

        public NewsController(INewsService news, IVotesService votes)
        {
            this.news = news;
            this.votes = votes;
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

        [Authorize]
        [HttpPost]
        public ActionResult Vote(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var vote = this.votes
                .All()
                .FirstOrDefault(v => v.VoterId == userId && v.NewsId == id);

            if (vote == null)
            {
                var newVote = new Vote();
                newVote.NewsId = id;
                newVote.VoterId = userId;
                this.votes.Add(newVote);
            }

            var votesCount = this.news
                .All()
                .FirstOrDefault(n => n.Id == id)
                .Votes.Count();

            return this.Json(new { Count = votesCount });
        }

        public ActionResult Index(string order, int id = 1)
        {
            var newsCount = this.news
                .All()
                .Count();
            var page = id;
            var pages = (int)Math.Ceiling(newsCount / NewsPerPage);
            var skip = (page - 1) * NewsPerPage;

            var allNews = this.news
                .All();

            var orderType = order;
            IOrderedQueryable<News> orderedNews = null;
            if (orderType == "date")
            {
                orderedNews = allNews.OrderBy(n => n.CreatedOn).ThenBy(n => n.Id);
            }
            else
            {
                orderedNews = allNews.OrderByDescending(n => n.Votes.Count()).ThenBy(n => n.Id);
            }

            var news = orderedNews
                .Skip((int)skip)
                .Take((int)NewsPerPage)
                .To<NewsViewModel>()
                .ToList();

            var viewModel = new NewsIndexViewModel()
            {
                News = news,
                Page = page,
                Pages = pages,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.TeacherRoleName)]
        [HttpGet]
        public ActionResult AddNews()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.TeacherRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(NewsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();
            var news = new News()
            {
                AuthorId = userId,
                Title = model.Title,
                Content = model.Content,
            };

            this.news.Add(news);

            return this.RedirectToAction("Details", new { id = news.Id });
        }
    }
}
