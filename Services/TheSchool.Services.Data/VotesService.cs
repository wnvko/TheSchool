namespace TheSchool.Services.Data
{
    using System.Linq;
    using TheSchool.Data.Common;
    using TheSchool.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IDbRepositoryInty<Vote> votes;

        public VotesService(IDbRepositoryInty<Vote> votes)
        {
            this.votes = votes;
        }

        public Vote Add(Vote vote)
        {
            this.votes.Add(vote);
            this.votes.Save();
            return vote;
        }

        public IQueryable<Vote> All()
        {
            return this.votes.All();
        }
    }
}
