namespace TheSchool.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.News;

    public class NewsController : Controller
    {
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
    }
}