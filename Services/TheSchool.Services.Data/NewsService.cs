namespace TheSchool.Services.Data
{
    using System;
    using System.Linq;
    using TheSchool.Data.Common;
    using TheSchool.Data.Models;

    public class NewsService : INewsService
    {
        private readonly IDbRepositoryInty<News> news;

        public NewsService(IDbRepositoryInty<News> news)
        {
            this.news = news;
        }

        public News Add(News news)
        {
            this.news.Add(news);
            this.news.Save();
            return news;
        }

        public IQueryable<News> All()
        {
            return this.news.All();
        }

        public void Delete(News news)
        {
            this.news.Delete(news);
        }

        public News GetById(int id)
        {
            return this.news.GetById(id);
        }

        public IQueryable<News> GetLatestTenNews()
        {
            return this.news
                .All()
                .OrderByDescending(n => n.CreatedOn)
                .Take(10);
        }

        public void Save()
        {
            this.news.Save();
        }
    }
}
