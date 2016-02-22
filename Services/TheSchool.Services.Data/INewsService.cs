namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface INewsService
    {
        News Add(News news);

        IQueryable<News> All();

        void Delete(News news);

        News GetById(int id);

        IQueryable<News> GetLatestTenNews();

        void Save();
    }
}
