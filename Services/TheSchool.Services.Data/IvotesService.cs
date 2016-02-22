namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Models;

    public interface IVotesService
    {
        Vote Add(Vote vote);

        IQueryable<Vote> All();
    }
}
